using UnityEngine;

public class EnemyManager : MonoBehaviour, IFollowable, IDamageable
{
    [SerializeField] private GameObject _model;
    [SerializeField] private EnemyAction _action;
    public EnemyAction Action => _action;
    [SerializeField] private EnemyControl _enemyControl;
    [SerializeField] private Transform _target;

    [Header("HP")]
    [SerializeField] private HPBar _hpbar;
    [SerializeField] private float _maxHP = 100f;

    [Header("Collider")]
    [SerializeField] private Collider _bodyCollider;
    [SerializeField] private Collider _rightHandCollider;
    public Collider RightHandCollider => _rightHandCollider;

    private float _hp;
    public float HP => _hp;
    public Transform Target
    {
        get => _target;
        set => _target = value;
    }
    public bool IsDeath { get; private set; } = false;


    void OnEnable()
    {
        _hp = _maxHP;
    }

    void Start()
    {
        _rightHandCollider.enabled = false;
        _hpbar.ResetHP(_maxHP);
    }

    public void GetHit(float damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, _maxHP);
        UpdateHealthBar();

        if (_hp <= 0)
        {
            IsDeath = true;
            _bodyCollider.enabled = false;
            _rightHandCollider.enabled = false;
            Action.SetDeath();
        }
    }

    void UpdateHealthBar()
    {
        _hpbar.UpdateHP(_hp);
    }
}