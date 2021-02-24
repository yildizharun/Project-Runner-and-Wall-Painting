using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Platform : Rotating_Obstacle
{
    void FixedUpdate() 
    {
        Rotate_Obstacle(0, 0, 1);
    }
}
