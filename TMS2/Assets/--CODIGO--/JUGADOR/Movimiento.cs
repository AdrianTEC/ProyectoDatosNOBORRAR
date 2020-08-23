using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{	
	private Rigidbody rb;
	private  float audioSpeed=1f;//
 	private AudioSource Audio;
    private float FuerzaActual;
	private float constanteFuerza=0.5f;
    public float constanteRotacion=300;
	private int  constanteVelocidad =5;
    private float  VelocidadMaximaActual;
    private string ultimaTeclaPresionada;
	private Animator Anim;
	private bool usingShield=false;
	private int constanteSaltos=3;
	private int actualSaltos=0;
	public bool Inventario=false;
	//Reproduce un sonido

	public void Playthesound()
		{
            
			Audio.pitch=audioSpeed*0.8f;
	   		if (true){if (!Audio.isPlaying){Audio.Play();}}

	    }

    void Start()
		{
			rb= gameObject.GetComponent<Rigidbody>();
			Audio= GetComponent<AudioSource>();
    	    Anim=gameObject.GetComponent<Animator>();
			VelocidadMaximaActual=constanteVelocidad;
			FuerzaActual=constanteFuerza;
		}

    void Update()
		{

            // Debug.Log("me muevo a " + rb.velocity);
			if (!usingShield &&(Input.GetKey("w")||Input.GetKey("a")||Input.GetKey("s")||Input.GetKey("d")))
				{
					if (Input.GetKey("w"))
						{
							rb.AddForce(transform.forward*FuerzaActual, ForceMode.VelocityChange);

						}
					if(Input.GetKey("a")&&!Input.GetKey("space"))
						{
			
									rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, -constanteRotacion, 0) * Time.deltaTime));
						
						}  
					if(Input.GetKey("s"))
						{
										rb.AddForce(-transform.forward*FuerzaActual , ForceMode.VelocityChange);
								

						}      
					if(Input.GetKey("d")&&!Input.GetKey("space"))
						{
								
										rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, constanteRotacion, 0) * Time.deltaTime));
					
						}
			        Anim.SetBool("caminando",true);
				}
			else
				{
					Anim.SetBool("caminando",false);
				}



			if(Input.GetKeyDown("space"))
                {
					salto();
                }

			if(Input.GetKey("a")&&Input.GetKeyDown("space"))
				{
					Vector3 direccion=new Vector3(0,1,0);
	
							rb.AddForce(-transform.right*FuerzaActual*2+direccion, ForceMode.Impulse);
				

				}  
			if(Input.GetKey("d")&&Input.GetKeyDown("space"))
				{
					
					Vector3 direccion=new Vector3(0,1,0);

							rb.AddForce(transform.right*FuerzaActual*2+direccion, ForceMode.VelocityChange);
						
			
				}



	        if(Input.GetMouseButtonDown(0)&&!Inventario)
				{
						Anim.SetBool("ataque",true);
						Anim.SetInteger("combo",Anim.GetInteger("combo")+1);
 						Invoke("stopAttack", 0.5f);
				}

	        if(Input.GetMouseButton(1)&&!Inventario)
				{
						Anim.SetBool("escudo",true);
						usingShield=true;
				}
			else
				{
						Anim.SetBool("escudo",false);
						usingShield=false;


				}
			//REGULADOR VELOCIDAD
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, VelocidadMaximaActual);
		
			//COLISION CON EL SUELO
			RaycastHit hit;
			if (Physics.Raycast(transform.position, -transform.up+ new Vector3(0,0,0), out hit, 0.1f))
				{
					actualSaltos=constanteSaltos;
					Anim.SetBool("volando",false);

				}
			else
				{
				//	Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * 1000, Color.red);
						Anim.SetBool("volando",true);
					
				}

		}	
	void salto()
		{
			Vector3 direccion=new Vector3(0,6,0);
			if(actualSaltos>0)
				{
					actualSaltos--;
					rb.AddForce(new Vector3(0,6,0) , ForceMode.VelocityChange);
				}
		}
	void stopAttack()
		{
			Anim.SetBool("ataque",false);
			Anim.SetInteger("combo",0);

		}


}
