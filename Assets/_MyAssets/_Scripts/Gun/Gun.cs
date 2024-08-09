using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected Transform _firePoint;
    public Transform FirePoint => _firePoint;
    [SerializeField] protected ParticleSystem _effect;
    [SerializeField] protected float _shootRate;
    protected float _shootTimer = 0;



    protected virtual void Start()
    {
        _effect.Stop();
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
        _effect.time = 0;
        _effect.Play();
        StartCoroutine(StopEffectAfter(_shootRate / 3f));
        AmmoPool.Singleton.Get(AmmoPool.AmmoName.Bullet, callback: go =>
       {
           go.transform.position = FirePoint.position;
           go.transform.rotation = FirePoint.rotation;
       });
    }

    IEnumerator StopEffectAfter(float sec)
    {
        yield return new WaitForSeconds(sec);
        _effect.Stop();
    }
}