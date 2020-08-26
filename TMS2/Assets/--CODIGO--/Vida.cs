using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
	private Rigidbody rb;
	private Animator Anim;
    private bool puedoRecibirDano;
    public int HP;

    public Vector3 ubicacion;

    public GameObject text;
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
            valor=valor + Random.Range(-valor/2,valor/2);
            GameObject NuevoTexto=Instantiate(text);
            NuevoTexto.transform.SetParent(transform); 
            NuevoTexto.GetComponent<TextMesh>().text=valor.ToString();

            NuevoTexto.transform.position= transform.position + ubicacion;
            NuevoTexto.transform.forward= -transform.forward;

            if(puedoRecibirDano)
                {  
                    puedoRecibirDano= false;
                    Anim.SetBool("injured",true);
                    HP-=valor;
                    //Debug.Log(HP);
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
