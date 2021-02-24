using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Look_At : MonoBehaviour
{
    public Input_Vector Input_Vector;

    void Update()
    {
        //If User is touching the screen and has swiped, just look at the move direction
        
        if (Input_Vector.isPressing && Input_Vector.Get_Input_Vector() != Vector2.zero && !Game_Manager.Instance.isRunnerOver)
        {
            transform.LookAt(Get_Look_Target());
        }
    }

    //Returns the target for getting look at
    Vector3 Get_Look_Target()
    {
        return transform.position + new Vector3(Input_Vector.Get_Input_Vector().x * 10, 0, Input_Vector.Get_Input_Vector().y * 10);
    }
}
