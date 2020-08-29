using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ModoBOT : MonoBehaviour
{	
	public GameObject Target;
	public NavMeshAgent agent;
	public float distance;
	public float AttackDistance;
	private Animator Anim;
    private bool quieto=false;

    void Start()
    {
        Anim= gameObject.GetComponent<Animator>();
        Target=GameObject.Find("PATO");
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

        if(Input.GetKeyDown("v"))
            {   
                quieto=!quieto;
            }
        if(!quieto)
            {
                
                if(Target!=null)
                    {                
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

    }		
}
