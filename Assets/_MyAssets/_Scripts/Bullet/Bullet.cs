using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _damage = 50;
    [SerializeField] private LayerMask _enemyLayer;

    void OnEnable()
    {
        _rigidBody.velocity = this.transform.forward * _speed;
        StartCoroutine(ReleaseAfterCoroutine(5f)); 
    }

    void Start()
    {
    }

    IEnumerator ReleaseAfterCoroutine(float sec)
    {
        yield return new WaitForSeconds(sec);
        Release();
    }

    void Release()
    {
        BulletPool.Singleton.Release(this.gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        var root = other.transform.root;
        // Debug.Log($"{1 << root.gameObject.layer} {_enemyLayer.value}");
        if (1 << root.gameObject.layer == _enemyLayer.value)
        {
            root.GetComponent<IDamageable>()?.GetHit(_damage);
        }

        _rigidBody.velocity = Vector3.zero;
        _rigidBody.detectCollisions = false;
        StartCoroutine(ReleaseAfterCoroutine(1f));
    }
}