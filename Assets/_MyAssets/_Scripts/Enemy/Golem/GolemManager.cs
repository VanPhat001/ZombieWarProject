using System;
using System.Collections;
using UnityEngine;

public class GolemManager : MonoBehaviour, IFollowable, IDamageable, IAliveable
{
    [SerializeField] private GameObject _model;
    [SerializeField] private GolemAction _action;
    public GolemAction Action => _action;
    [SerializeField] private GolemControl _golemControl;
    [SerializeField] private Transform _target;

    [Header("HP")]
    [SerializeField] private HPBar _hpbar;
    [SerializeField] private float _maxHP = 100f;

    [Header("Sound")]
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioSource _audioSource;

    [Header("Collider")]
    [SerializeField] private Collider _bodyCollider;
    [SerializeField] private Collider _headCollider;
    public Collider HeadCollider => _headCollider;

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
        IsDeath = false;
        _hp = _maxHP;
        _bodyCollider.enabled = true;
        _headCollider.enabled = false;
        _hpbar.ResetHP(_maxHP);
        // _golemControl.Agent.baseOffset = 0;


        // StartCoroutine(Test());
        // IEnumerator Test()
        // {
        //     while (_hp > 0)
        //     {
        //         yield return new WaitForSeconds(1);
        //         GetHit(10);
        //     }
        // }
    }

    void Start()
    {

    }

    void OnDisable()
    {

    }

    public void GetHit(float damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, _maxHP);
        UpdateHealthBar();

        if (_hp <= 0)
        {
            IsDeath = true;
            _bodyCollider.enabled = false;
            _headCollider.enabled = false;
            // _golemControl.Agent.baseOffset = _golemControl.Agent.height / -2f;
            _golemControl.Agent.isStopped = true;
            PlayDeathSound();
            Action.SetDeath();
            StartCoroutine(ReleaseAfter(4));
        }
    }

    void PlayDeathSound()
    {
        _audioSource.PlayOneShot(_deathSound);
    }

    void UpdateHealthBar()
    {
        _hpbar.UpdateHP(_hp);
    }

    IEnumerator ReleaseAfter(float sec)
    {
        yield return new WaitForSeconds(sec);
        Release();
    }

    public void Release()
    {
        EnemyPool.Singleton.Release(this.gameObject);
    }

    public bool IsAlive()
    {
        return !IsDeath;
    }
}