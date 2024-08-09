using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _explosionAfterSecond;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _model;
    [SerializeField] private ParticleSystem _effect;


    void OnEnable()
    {
        _effect.time = 0;
        _effect.Stop();

        _rigidbody.AddForce((this.transform.forward.normalized + this.transform.up.normalized) * _force);
        _model.gameObject.SetActive(true);

        StartCoroutine(ExplosionAfterCoroutine(_explosionAfterSecond));
    }

    void Start()
    {
    }

    IEnumerator ExplosionAfterCoroutine(float sec)
    {
        yield return new WaitForSeconds(sec);
        Explosion();

        yield return new WaitForSeconds(5);
        Release();
    }

    void Explosion()
    {
        // invisible grenade model
        _model.gameObject.SetActive(false);

        // play effect
        _effect.time = 0;
        _effect.Play();

        // play sound
        //

        // collision range - 1 enemy have many collider
        var colliders = Physics.OverlapSphere(this.transform.position, _explosionRadius, _enemyLayer.value);
        Dictionary<int, Transform> dic = new();
        foreach (var collider in colliders)
        {
            var root = collider.transform.root;
            if (dic.ContainsKey(root.GetInstanceID()))
            {
                continue;
            }
            dic.Add(root.GetInstanceID(), root);
        }

        foreach (var item in dic.Values)
        {
            item.GetComponent<IDamageable>()?.GetHit(_damage);
        }
    }

    void Release()
    {
        AmmoPool.Singleton.Release(this.gameObject);
    }


    void OnDrawGizmos()
    {
        var color = Color.blue;
        color.a = .1f;
        Gizmos.color = color;
        Gizmos.DrawSphere(this.transform.position, _explosionRadius);
    }
}