using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    //Player's Animation
    public Animator animator;
    //Input Vector's Reference
    public Input_Vector Input_Vector;


    void Update()
    {
        Control_The_Animator();
    }
    void Control_The_Animator()
    {
        //If User Swerve Play Running Animation
        if (Input_Vector.Get_Input_Vector() != Vector2.zero && !Game_Manager.Instance.isRunnerOver)
        {
            animator.SetBool("isRunning", true);
        }
        //Else Play Idle Animation
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
