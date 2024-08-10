using System.Collections;
using System.Collections.Generic;
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
        var index = Random.Range(0, _spawnPoints.Count);
        return SpawnBH2(index);
    }

    protected Transform SpawnRandomBH2()
    {
        var index = Random.Range(0, _spawnPoints.Count);
        return SpawnBH2(index);
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
}