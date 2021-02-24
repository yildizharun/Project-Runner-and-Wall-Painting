using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public float xOffset,yOffset,zOffset;

    public Ragdoll_Controller ragdoll_Controller;

    Vector3 targetPosition;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    
    void Update()
    {
        if(ragdoll_Controller.isFollow)
        {
            Follow();
        }
    }
    void Follow()
    {
        targetPosition = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
