using UnityEngine;

public class EnemyPool : Pool<EnemyPool.EnemyName>
{
    public static EnemyPool Singleton { get; private set;}

    public enum EnemyName
    {
        BH_2
    }

    void Awake()
    {
        Singleton = this;
    }

    protected override bool Compare(EnemyName a, EnemyName b)
    {
        return a == b;
    }

    protected override bool Compare(EnemyName a, string b)
    {
        return a.ToString() == b;
    }
}