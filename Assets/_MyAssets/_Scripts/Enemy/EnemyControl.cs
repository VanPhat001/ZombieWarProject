using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    private NavMeshAgent _agent;
    private EnemyManager _enemyManager;
    private float _timer = 0;
    private float _attackRate = 2.5f;
    private Coroutine _coroutine = null;


    private void Start()
    {
        _enemyManager = this.GetComponentInParent<EnemyManager>();
        _agent = this.GetComponentInParent<NavMeshAgent>();
        // _agent.isStopped = false;
        _enemyManager.Action.SetWalk();
    }


    private void Update()
    {
        if (_enemyManager.IsDeath)
        {
            return;
        }

        _timer -= Time.deltaTime;

        if (CanMove())
        {
            FollowTarget();
        }
        else
        {
            Attack();
        }
    }


    private bool CanMove()
    {
        if (Vector3.Distance(_enemyManager.Target.position, _enemyManager.transform.position) <= _agent.stoppingDistance)
        {
            return false;
        }

        return true;
    }


    private void FollowTarget()
    {
        _agent.SetDestination(_enemyManager.Target.position);
    }


    private void Attack()
    {
        if (_timer > 0)
        {
            return;
        }

        _timer = _attackRate;
        _enemyManager.Action.SetAttack();
        _enemyManager.RightHandCollider.enabled = true;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(DisableHandCollider());
    }

    IEnumerator DisableHandCollider()
    {
        yield return new WaitForSeconds(2f);
        _enemyManager.RightHandCollider.enabled = false;
    }
}