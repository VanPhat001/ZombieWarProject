using UnityEngine;

public class AmmoPool : Pool<AmmoPool.AmmoName>
{
    public enum AmmoName
    {
        Bullet,
        Grenade
    }


    public static AmmoPool Singleton { get; private set; }

    void Awake()
    {
        Singleton = this;
    }


    protected override bool Compare(AmmoName a, AmmoName b)
    {
        return a == b;
    }

    protected override bool Compare(AmmoName a, string b)
    {
        return a.ToString() == b;
    }

}