using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected Transform _firePoint;
    public Transform FirePoint => _firePoint;
    [SerializeField] protected float _shootRate;
    protected float _shootTimer = 0;



    protected virtual void Start()
    {
    }


    protected virtual void Update()
    {
        _shootTimer -= Time.deltaTime;
    }


    public virtual bool CanShoot()
    {
        return _shootTimer <= 0;
    }


    public virtual void Shoot()
    {
        if (!CanShoot())
        {
            return;
        }

        _shootTimer = _shootRate;
        AmmoPool.Singleton.Get(AmmoPool.AmmoName.Bullet, callback: go =>
       {
           go.transform.position = FirePoint.position;
           go.transform.rotation = FirePoint.rotation;
       });
    }
}