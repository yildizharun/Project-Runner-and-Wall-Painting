using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    public Painter painter;
    Vector3 currentVelocity;
    [SerializeField]
    float smoothTime;
    bool isPressing = false;
    float zPosition;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressing = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPressing = false;
        }
        transform.LookAt(painter.hit.point);
        if (isPressing)
        {
            zPosition = 53f;
        }
        else
        {
            zPosition = 52f;
        }
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(painter.hit.point.x, painter.hit.point.y, zPosition),ref currentVelocity,smoothTime);
    }
}
