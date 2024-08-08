using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField] private Transform _model;
    public Transform Model => _model;

    [SerializeField] private PlayerMoverment _moverment;
    public PlayerMoverment Moverment => _moverment;

    [SerializeField] private PlayerShoot _shoot;
    public PlayerShoot Shoot => _shoot;

    [SerializeField] private Rigidbody _rigidbody;
    public Rigidbody Rigid => _rigidbody;

    [SerializeField] private Animator _animator;
    public Animator Anim => _animator;

    [SerializeField] private HPBar _hpBar;
    [SerializeField] private float _maxHP;

    public float HP { get; private set; }


    void Start()
    {
        HP = _maxHP;
        _hpBar.ResetHP(_maxHP);
        // UpdateHealthBar();
    }


    public void GetHit(float damage)
    {
        HP = Mathf.Clamp(HP - damage, 0, _maxHP);
        UpdateHealthBar();

        if (HP <= 0)
        {
            // end game
        }
    }

    void UpdateHealthBar()
    {
        _hpBar.UpdateHP(HP);
    }
}