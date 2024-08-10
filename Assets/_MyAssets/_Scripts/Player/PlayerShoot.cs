using UnityEngine;
using UnityEngine.AI;

public class PlayerShoot : MonoBehaviour
{
    private PlayerManager _playerManager;

    [SerializeField] private float _detectRange = 12f;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _aimPoint;
    [SerializeField] private Transform _freePoint;
    [SerializeField] private PlayerWeaponManager _weaponManager;
    public bool DetectEnemy { get; private set; } = false;

    void Start()
    {
        _playerManager = this.GetComponentInParent<PlayerManager>();
    }

    void Update()
    {
        if (_playerManager.HP <= 0)
        {
            return;
        }
        
        AutoShoot();
    }

    void AutoShoot()
    {
        var enemy = DetectNearestEnemy();
        if (enemy == null)
        {
            DetectEnemy = false;
            _aimPoint.position = _freePoint.position;
            return;
        }

        DetectEnemy = true;
        _playerManager.Model.rotation = enemy.transform.rotation;
        _playerManager.Model.Rotate(0, 180, 0);
        _aimPoint.position = enemy.GetComponent<Collider>().bounds.center;

        if (!_weaponManager.GetCurrentWeapon().CanShoot())
        {
            return;
        }

        _playerManager.Anim.SetTrigger("shoot");
        _weaponManager.GetCurrentWeapon().Shoot();
    }

    GameObject DetectNearestEnemy()
    {
        var colliders = Physics.OverlapSphere(this.transform.position, _detectRange, _enemyLayer.value);
        if (colliders.Length == 0)
        {
            return null;
        }

        float minRange = _detectRange + 1;
        Collider value = null;
        foreach (var collider in colliders)
        {
            // Debug.Log(collider.transform.name);
            if (!collider.transform.parent.TryGetComponent<IAliveable>(out var comp) || !comp.IsAlive())
            {
                continue;
            }

            var d = Vector3.Distance(this.transform.position, collider.transform.position);
            if (minRange > d)
            {
                minRange = d;
                value = collider;
            }
        }

        return value?.gameObject;
    }

    void OnDrawGizmos()
    {
        var color = Color.yellow;
        color.a = .13f;
        Gizmos.color = color;

        Gizmos.DrawSphere(this.transform.position, _detectRange);
    }

    public void ThrowGrenade()
    {
        // Debug.Log("Throw grenade");
        AmmoPool.Singleton.Get(AmmoPool.AmmoName.Grenade, callback: go => {
            var firePoint = _weaponManager.GetCurrentWeapon().FirePoint;
            go.transform.position = firePoint.position;
            go.transform.rotation = firePoint.rotation;
        });
    }

    public void ChangeWeapon()
    {
        switch (_weaponManager.CurrentWeaponName)
        {
            case PlayerWeaponManager.WeaponName.M416:
                _weaponManager.UseWeapon(PlayerWeaponManager.WeaponName.K98);
                break;

            default:
                _weaponManager.UseWeapon(PlayerWeaponManager.WeaponName.M416);
                break;
        }
    }
}