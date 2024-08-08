using UnityEngine;

public class BulletPool : Pool<BulletPool.BulletName>
{
    public enum BulletName
    {
        Bullet
    }

    public static BulletPool Singleton { get; private set; }

    void Awake()
    {
        Singleton = this;
    }

    protected override bool Compare(BulletName a, BulletName b)
    {
        return a == b;
    }

    protected override bool Compare(BulletName a, string b)
    {
        return a.ToString() == b;
    }
}