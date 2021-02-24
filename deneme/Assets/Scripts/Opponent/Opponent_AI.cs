using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent_AI : MonoBehaviour
{
    public Animator animator;
    public Transform[] target;
    NavMeshAgent navMeshAgent;
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(target[0].position);
    }
    void Update()
    {
        Destination_Selector();

        if(Mathf.Abs((transform.position - target[11].transform.position).magnitude) <= .5f)
        {
            animator.SetBool("isRunning", false);
        }
    }
    void Destination_Selector()
    {
        
        if (Mathf.Abs((transform.position - target[i].transform.position).magnitude) <= 1f)
        {
            if(i<11)
            {
                i++;
            }
            navMeshAgent.SetDestination(target[i].position);
        }
    }
    
}
