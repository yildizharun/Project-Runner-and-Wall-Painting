using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Obstacle : Obstacle  
{
    [SerializeField]
    private float rotateSpeed = 50;

    public void Rotate_Obstacle(float xAxis, float yAxis, float zAxis)
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(xAxis, yAxis, zAxis) * Time.deltaTime * rotateSpeed);
        obstacleRigidbody.MoveRotation(obstacleRigidbody.rotation * deltaRotation);
    }
}
