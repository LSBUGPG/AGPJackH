using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float angle = 30.0f;
    public float smooth = 1.0f;
    Vector3 velocity;

    void LateUpdate()
    {
        float r = Mathf.Deg2Rad * angle;
        Vector3 back = Vector3.Cross(target.right, Vector3.up) * distance * Mathf.Cos(r);
        Vector3 up = Vector3.up * distance * Mathf.Sin(r);
        Vector3 position = target.position - back + up;
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smooth);
        transform.LookAt(target.position);
    }
}
