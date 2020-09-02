using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ModoBOT : MonoBehaviour
{	
	public GameObject companero;
    public GameObject target;
    private GameObject currentFollowing;
	public NavMeshAgent agent;
	
	public float AttackDistance;
    public float STOP_distance;
    public bool enBuscaDePelea;
	private Animator Anim;
    private bool quieto=false;
    private TAMANO controlDeBarra;
    private Apuntado apuntado;
    private bool puedoAtacar=true;
    private int estado=1;
    void Start()
        {
            Anim= gameObject.GetComponent<Animator>();
            apuntado=gameObject.transform.GetChild(2).gameObject.GetComponent<Apuntado>();
            controlDeBarra= gameObject.GetComponent<Vida>().estatus.transform.GetChild(0).gameObject.GetComponent<TAMANO>();
            StopAttack();

            agent.stoppingDistance=STOP_distance;
        }


    public void Attack()
    	{
            GameObject thing = apuntado.getMasCercano();
            if(thing!=null)
                {
                    enBuscaDePelea=true;
                    currentFollowing=thing;
                }
            else
                {
                    StopAttack();
                    aumentarEstado();
                }
             

    	}

    void StopAttack()
    	{
            currentFollowing= companero;
            enBuscaDePelea=false;

    	}

    private void aumentarEstado()
        {
            estado+=1;
            if(estado>2)
                {
                    estado=0;
                }
            controlDeBarra.activarEstado(estado);
        }
    void Update()
        {		

            if(Input.GetKeyDown("v"))
                {   
                    aumentarEstado();
                    if(estado==0)
                        {
                            Attack();
                            quieto=false;

                        }
                    if(estado==1)
                        {
                            StopAttack();
                            quieto=false;
                        }
                    if(estado==2)
                        {
                            quieto=true;
                        }
                }
            if(!quieto)
                {
                    
                    if(currentFollowing!=null)
                        {                
                                float dis= Vector3.Distance(currentFollowing.transform.position,transform.position);
                                transform.LookAt(currentFollowing.transform.position);
                                transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);

                                //Debug.DrawLine(gameObject.transform.position,currentFollowing .transform.position ,Color.red);
                                //Debug.Log(dis);

                                if( dis >AttackDistance)//si esta lo suficientemente largo para no poder atacar
                                    {
                                        Anim.SetBool("caminando",true);
                                        agent.SetDestination(currentFollowing.transform.position);
                                        agent.speed=3;
                                    }
                                else
                                    {

                                        
                                            if(dis>AttackDistance-1 && dis<=AttackDistance+1)//posicion de ataque
                                                {
                                                    agent.speed=0;
                                                    Anim.SetBool("caminando",false);
                                                     Debug.Log("en zona de ataque");
                                                    if(enBuscaDePelea&&puedoAtacar)
                                                        {
                                                            puedoAtacar=false;
                                                            Anim.SetBool("ataque",true); 
                                                            Invoke("restoreattack",1f);
                                                        }

                                                }
                                            if(enBuscaDePelea)
                                            {
                                                if(dis<=AttackDistance-1)//si está demasiado cerca alejese
                                                    {
                                                        Anim.SetBool("caminando",true);

                                                        int constante= 5;
                                                        Vector3 posicion= transform.position*(1+constante)- constante*currentFollowing.transform.position;

                                                        //Debug.DrawLine(gameObject.transform.position,posicion ,Color.red);
                                                        //Debug.Log("alejandose");

                                                        agent.SetDestination(posicion);
                                                        agent.speed=5;

                                                    }
                                            }
                                            else
                                                {
                                                    Anim.SetBool("caminando",false);

                                                }
                                    
                                        
                                    }
                        }
                    else
                        {
                            if(enBuscaDePelea)
                                {
                                    Attack();
                                }
                            else
                                {
                                    currentFollowing=companero;
                                }
                        }
                }    
            else
                {
                                    Anim.SetBool("caminando",false);
                    
                }

        }
    void restoreattack()
        {
            Anim.SetBool("ataque",false); 
            puedoAtacar=true;
        }
}
