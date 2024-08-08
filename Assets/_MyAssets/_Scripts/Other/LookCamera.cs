using UnityEngine;

public class LookCamera : MonoBehaviour
{
    private Camera _cam;

    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        this.transform.LookAt(_cam.transform.position);
    }
}