using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
	private Rigidbody rb;
	private Animator Anim;
    private bool puedoRecibirDano;
    public int HP;

    void Start()
    {
		rb= gameObject.GetComponent<Rigidbody>();
    	Anim=gameObject.GetComponent<Animator>();
        puedoRecibirDano=true;
    }


    public void propulsar(Vector3 direccion, int empuje)
        {
                rb.AddForce(direccion*empuje,ForceMode.VelocityChange);
        }

    public void restarHP(int valor)
        {
            if(puedoRecibirDano)
                {  
                    puedoRecibirDano= false;
                    Anim.SetBool("injured",true);
                    HP-=valor;
                    Debug.Log(HP);
                    if(HP<=0)
                        {
                                Anim.SetBool("dead",true);
                                if(this.gameObject.tag=="enemy")
                                    {
                                        gameObject.GetComponent<IA>().enabled=false;
                                    }
                                Invoke("desaparecer",4);
                        }
                    Invoke("capacitarParaRecibirdano",0.5f);    
                    
                }

        }
    public void desaparecer()
        {
            Destroy(this.gameObject);
        }
    public void capacitarParaRecibirdano()
        {
            Anim.SetBool("injured",false);
            puedoRecibirDano=true;

        }
}
