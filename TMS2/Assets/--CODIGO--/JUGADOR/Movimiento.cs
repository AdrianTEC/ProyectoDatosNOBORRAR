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

	private int constanteSaltos=3;
	private int actualSaltos=0;
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
			if (Input.GetKey("w")||Input.GetKey("a")||Input.GetKey("s")||Input.GetKey("d"))
				{
					if (Input.GetKey("w"))
						{
							rb.AddForce(transform.forward*FuerzaActual, ForceMode.VelocityChange);

						}
					if(Input.GetKey("a"))
						{

							//rb.AddForce(transform.right*-FuerzaActual, ForceMode.VelocityChange);
							rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, -constanteRotacion, 0) * Time.deltaTime));
						}  
					if(Input.GetKey("s"))
						{
							rb.AddForce(-transform.forward*FuerzaActual , ForceMode.VelocityChange);

						}      
					if(Input.GetKey("d"))
						{
							//rb.AddForce(transform.right*FuerzaActual, ForceMode.VelocityChange);
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
					if(actualSaltos>0)
					{
						actualSaltos--;
						rb.AddForce(new Vector3(0,6,0) , ForceMode.VelocityChange);
				    }

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

}
