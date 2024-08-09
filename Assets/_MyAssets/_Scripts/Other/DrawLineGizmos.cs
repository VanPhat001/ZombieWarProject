using UnityEngine;

public class DrawLineGizmos : MonoBehaviour
{
    [SerializeField] private float _length = 10f;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        

        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward.normalized * _length);
    }
}