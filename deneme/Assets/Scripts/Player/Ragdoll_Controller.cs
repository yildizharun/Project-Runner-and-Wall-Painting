using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ragdoll_Controller : MonoBehaviour
{
    public Transform start;
    [SerializeField]
    Player_Movement player_Movement;

    NavMeshAgent navMeshAgent;
    public GameObject animatorCharacter;
    
    Opponent_AI opponent_AI;

    public bool isFollow = true;//for camera following

    void Start()
    {
        Try_Getting_Components();
    }
    void Update()
    {
        if(transform.position.y <= -2.8f)
        {
            Reset_From_Fall();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (isFollow)
            {
                isFollow = false;

                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
                try
                {
                    navMeshAgent.speed = 0;
                }
                catch
                {
                    player_Movement.moveSpeed = 0;
                }
                
                animatorCharacter.SetActive(false);
                Spawn_Ragdoll(gameObject.tag);
                
            }
        }
    }
    IEnumerator Reset_Position()
    {
        transform.position = start.position;
        yield return new WaitForSeconds(1.9f);

        gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
       
        animatorCharacter.SetActive(true);

        
        isFollow = true;
        try
        {
            navMeshAgent.speed = 1.75f;
            opponent_AI.i = 0;
        }
        catch
        {
            player_Movement.moveSpeed = 100;
        }

    }
    void Reset_From_Fall()
    {
        transform.position = start.position;
    }
    void Spawn_Ragdoll(string tag)
    {
        GameObject ragdoll = ObjectPooler.Instance.spawnObjectFromPool(tag+"_Ragdoll", transform.position, Quaternion.identity);
        //ragdoll.transform.position = transform.position;
        StartCoroutine(Reset_Position());
    }
    void Try_Getting_Components()
    {
        try
        {
            opponent_AI = GetComponent<Opponent_AI>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        catch
        {
            Debug.Log("This is a player!");
        }
        try
        {
            player_Movement = GetComponent<Player_Movement>();
        }
        catch
        {
            Debug.Log("This is an opponent!");
        }
    }
}
