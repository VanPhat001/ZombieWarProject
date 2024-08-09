using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    private Transform _player;

    void Start()
    {

    }

    void OnEnable()
    {
        _player = GameObject.Find("Player").transform;

        // StartCoroutine(Test());
        // IEnumerator Test()
        // {
        //     while (true)
        //     {
        //         if (Time.time < 4 || (22 <= Time.time && Time.time <= 30))
        //         {
        //             yield return new WaitForSeconds(1);
        //             SpawnRandom();

        //             if (Time.time > 30)
        //             {
        //                 yield break;
        //             }
        //         }
        //         else
        //         {
        //             yield return new WaitForSeconds(.5f);
        //         }
        //         // Debug.Log(Time.time);
        //     }

        // }


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

    void Update()
    {

    }


    void SpawnRandom()
    {
        var index = Random.Range(0, _spawnPoints.Count);
        // Debug.Log(index);
        var spawnPoint = _spawnPoints[index];

        var zombie = EnemyPool.Singleton.Get(EnemyPool.EnemyName.BH_2, callback: go => {
            go.GetComponent<IFollowable>().Target = _player;
            go.transform.position = spawnPoint.position;
            go.transform.rotation = spawnPoint.rotation;
        }).transform;
    }
}