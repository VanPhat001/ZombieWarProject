using UnityEngine;

public class EnemyPool : Pool
{
    public static EnemyPool Singleton { get; private set;}

    void Awake()
    {
        Singleton = this;
    }
}