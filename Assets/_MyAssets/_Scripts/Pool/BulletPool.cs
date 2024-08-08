using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Singleton { get; private set; }

    void Awake()
    {
        Singleton = this;
    }
}