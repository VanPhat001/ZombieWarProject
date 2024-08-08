using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerManager _playerManager;

    [SerializeField] private float _detectRange = 12f;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _firePoint;
    public bool DetectEnemy { get; private set; } = false;
    private float _timer = 0;
    private float _rate = .3f;

    void Start()
    {
        _playerManager = this.GetComponentInParent<PlayerManager>();
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        AutoShoot();
    }

    void AutoShoot()
    {
        var enemy = DetectNearestEnemy();
        if (enemy == null)
        {
            DetectEnemy = false;
            return;
        }

        DetectEnemy = true;
        _playerManager.Model.rotation = enemy.transform.rotation;
        // _playerManager.Model.Rotate(0, 165, 0);
        _playerManager.Model.Rotate(0, 180, 0);

        if (!CanShoot())
        {
            return;
        }

        _timer = _rate;
        BulletPool.Singleton.Get(BulletPool.BulletName.Bullet, callback: go => {
            go.transform.position = _firePoint.position;
            go.transform.rotation = _playerManager.Model.rotation;
        });
        _playerManager.Anim.SetTrigger("shoot");
    }

    bool CanShoot()
    {
        return _timer <= 0;
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
}