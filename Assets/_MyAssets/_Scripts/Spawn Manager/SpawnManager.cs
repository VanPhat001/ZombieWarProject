using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public abstract class SpawnManager : MonoBehaviour
{
    [SerializeField] protected List<Transform> _spawnPoints;
    protected Transform _player;
    protected PlayerManager _playerManager;

    protected virtual void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _playerManager = _player.GetComponent<PlayerManager>();
    }

    protected virtual void OnEnable()
    {
        StartCoroutine(Test2());
        IEnumerator Test2()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f / 5);
                SpawnRandom();
            }
        }
    }

    protected virtual void Update()
    {
    }


    protected Transform SpawnRandom()
    {
        switch (UnityEngine.Random.Range(0, 2))
        {
            case 0:
                return SpawnRandomBH2();

            case 1:
                return SpawnRandomGolem();

            default:
                Debug.Log("index is out of range");
                break;
        }
        
        return null;
    }

    protected Transform SpawnRandomBH2()
    {
        var index = Random.Range(0, _spawnPoints.Count);
        return SpawnBH2(index);
    }

    protected Transform SpawnRandomGolem()
    {
        var index = Random.Range(0, _spawnPoints.Count);
        return SpawnGolem(index);
    }

    protected Transform SpawnBH2(int spawnPointIndex)
    {
        var spawnPoint = _spawnPoints[spawnPointIndex];
        var zombie = EnemyPool.Singleton.Get(EnemyPool.EnemyName.BH_2, callback: go =>
        {
            go.GetComponent<IFollowable>().Target = _player;
            go.transform.position = spawnPoint.position;
            go.transform.rotation = spawnPoint.rotation;
        }).transform;

        return zombie;
    }

    protected Transform SpawnGolem(int spawnPointIndex)
    {
        var spawnPoint = _spawnPoints[spawnPointIndex];
        var golem = EnemyPool.Singleton.Get(EnemyPool.EnemyName.Golem, callback: go =>
        {
            go.GetComponent<IFollowable>().Target = _player;
            go.transform.position = spawnPoint.position;
            go.transform.rotation = spawnPoint.rotation;
        }).transform;

        return golem;
    }
}