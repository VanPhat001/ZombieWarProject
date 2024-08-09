using UnityEngine;

public class LookObject : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void Update()
    {
        this.transform.LookAt(_target);
    }
}