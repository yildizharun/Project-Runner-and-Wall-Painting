using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Player Rigidbody
    public Rigidbody rigidbody;
    //Input From User
    public Input_Vector Input_Vector;
    //Player Move Speed
    public float moveSpeed;
    bool isFinished = false;

    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if(!isFinished)
        {
            //Set Player's Rigidbody Velocity using Input Vector
            Vector3 moveDirection = new Vector3(Input_Vector.Get_Input_Vector().x * Time.deltaTime * moveSpeed, rigidbody.velocity.y, Input_Vector.Get_Input_Vector().y * Time.deltaTime * moveSpeed);
            rigidbody.velocity = moveDirection;
        }
    }

    void Update()
    {
        if (transform.localPosition.z >= 60)
        {
            isFinished = true;
            //
            Game_Manager.Instance.isRunnerOver = true;
        }
    }
}
