using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : Rotating_Obstacle
{
    void FixedUpdate()
    {
        Rotate_Obstacle(0, 1, 0);
    }
}
