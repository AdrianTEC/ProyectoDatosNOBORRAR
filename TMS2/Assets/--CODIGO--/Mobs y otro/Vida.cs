using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
	private Rigidbody rb;
	private Animator Anim;
    private bool puedoRecibirDano;
    public int HP;
    
    public Sprite icon;
    public Vector3 ubicacion;
    public bool player=false;
    public GameObject text;

    public GameObject  estatusPREFAB;
    private GameObject  estatus;
    private RectTransform barraVida;
    private GameObject barraestamina;

    private float constanteOriginal;

    void Start()
    {
		rb= gameObject.GetComponent<Rigidbody>();
    	Anim=gameObject.GetComponent<Animator>();
        puedoRecibirDano=true;

        if(player)
            {
                estatus= Instantiate(estatusPREFAB);
                barraVida= estatus.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
                barraestamina=estatus.transform.GetChild(3).gameObject;

                constanteOriginal=barraVida.localScale.x/HP;

            }
    }


    public void propulsar(Vector3 direccion, int empuje)
        {
                rb.AddForce(direccion*empuje,ForceMode.VelocityChange);
        }

    public void restarHP(int valor)
        {   
            valor=valor + Random.Range(-valor/2,valor/2);


            if(!player)
                {
                    GameObject NuevoTexto=Instantiate(text);
                    NuevoTexto.transform.SetParent(transform); 
                    NuevoTexto.GetComponent<TextMesh>().text=valor.ToString();

                    NuevoTexto.transform.position= transform.position + ubicacion;
                    NuevoTexto.transform.forward= -transform.forward;
              
                }
            else
                {
                    barraVida.localScale= new Vector3(constanteOriginal*HP,barraVida.localScale.y,barraVida.localScale.z);
                }
            if(puedoRecibirDano)
                {  
                    puedoRecibirDano= false;
                    Anim.SetBool("injured",true);
                    HP-=valor;
                    Debug.Log(HP );
                    if(HP<=0)
                        {
                                Anim.SetBool("dead",true);
                                if(this.gameObject.tag=="enemy")
                                    {
                                        gameObject.GetComponent<IA>().enabled=false;
                                        puedoRecibirDano=false;
                                    }
                                if(player)
                                {Invoke("dead",4);}
                        }

                    Invoke("capacitarParaRecibirdano",0.5f);    
                    
                }

        }

    public void dead()
        {

        SceneManager.LoadScene("GameOver");


        }
    public void capacitarParaRecibirdano()
        {
            Anim.SetBool("injured",false);
            puedoRecibirDano=true;

        }
}
