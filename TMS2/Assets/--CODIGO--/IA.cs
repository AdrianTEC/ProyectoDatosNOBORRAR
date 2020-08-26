using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{	
	private GameObject Target;
	public NavMeshAgent agent;
	public float distance;
	public float AttackDistance;
	private Animator Anim;
    private RaycastHit hit;
    void Start()
    {
        Anim= gameObject.GetComponent<Animator>();
        Target= GameObject.FindGameObjectWithTag("Player");
    }

    void SetTrue()
        {

        }

    void Attack()
    	{
    	

    	}

    void StopAttack()
    	{
    	}
    void Update()
    {		


		    Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);

            agent.speed=10;
    		float dis= Vector3.Distance(Target.transform.position,transform.position);
            transform.LookAt(Target.transform.position);
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
        	if( dis<distance )
        		{
        			agent.SetDestination(Target.transform.position);
                    agent.speed=3;
        		}
        	else
                {
                        agent.speed=0;
                    
                }
    }		
}
