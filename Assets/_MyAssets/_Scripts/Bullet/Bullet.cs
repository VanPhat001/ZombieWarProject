using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _damage = 50;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioSource _audioSource;

    void OnEnable()
    {
        _rigidBody.detectCollisions = true;
        _rigidBody.velocity = this.transform.forward * _speed;
        StartCoroutine(ReleaseAfterCoroutine(5f));
    }

    void Start()
    {
    }

    void PlayeExplosionSound()
    {
        _audioSource.PlayOneShot(_explosionSound);
    }

    IEnumerator ReleaseAfterCoroutine(float sec)
    {
        yield return new WaitForSeconds(sec);
        Release();
    }

    void Release()
    {
        AmmoPool.Singleton.Release(this.gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        var root = other.transform.root;
        var rootLayer = 1 << root.gameObject.layer;

        if (rootLayer == _playerLayer.value)
        {
            return;
        }

        if (rootLayer == _enemyLayer.value)
        {
            root.GetComponent<IDamageable>()?.GetHit(_damage);
        }

        _rigidBody.velocity = Vector3.zero;
        _rigidBody.detectCollisions = false;
        StartCoroutine(ReleaseAfterCoroutine(1f));
    }
}