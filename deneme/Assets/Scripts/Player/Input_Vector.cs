using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Vector : MonoBehaviour
{
    //User Touching the screen or not
    public bool isPressing;
    //First touch position
    Vector2 firstTouchPosition;
    //Second touch position
    Vector2 secondTouchPosition;

    void Update()
    {
        //Check if user touching the screen or not
        Check_If_Pressing();
    }

    //Check if user touching the screen or not
    void Check_If_Pressing()
    {
        //User Started Touching
        if(Input.GetMouseButtonDown(0))
        {
            //Set the First Touch Position and make isPressing true
            Set_Touch_Position(ref firstTouchPosition);
            isPressing = true;
        }
        //User Stopped Touching
        if (Input.GetMouseButtonUp(0))
        {
            //Make isPressing false
            isPressing = false;
        }
        //If User  Currently touching the screen Set the Second Touch Position
        if(isPressing)
        {
            Set_Touch_Position(ref secondTouchPosition);
        }
        //Else Make Touch Input as Vector2.zero
        else
        {
            Reset_Touch_Input();
        }
    }
    //Return Input Vector with Calculating Second-First but normalized
    public Vector2 Get_Input_Vector()
    {
        return (secondTouchPosition - firstTouchPosition).normalized;
    }
    //Else Make Touch Input as Vector2.zero
    void Reset_Touch_Input()
    {
        firstTouchPosition = Vector2.zero;
        secondTouchPosition = Vector2.zero;
    }
    //Sets the first and second touch positions for vector calculation
    void Set_Touch_Position(ref Vector2 touchPosition)
    {
        touchPosition = Input.mousePosition;
    }
}
