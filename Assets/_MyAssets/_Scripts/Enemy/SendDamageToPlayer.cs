using UnityEngine;

public class SendDamageToPlayer : MonoBehaviour
{
    [SerializeField] float _damage;
    private int _playerLayer;

    void Awake()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        var root = other.transform.root;
        if (root.gameObject.layer == _playerLayer)
        {
            root.GetComponent<IDamageable>().GetHit(_damage);
        }
    }
}