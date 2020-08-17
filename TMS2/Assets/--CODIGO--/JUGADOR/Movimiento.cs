using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{	
	private Rigidbody rb;
	private  float audioSpeed=1f;//
 	private AudioSource Audio;
    private float constanteFuerza=0.5f;
    private float constanteRotacion=400;
    private int  constanteVelocidadMaxima=5;

    private string ultimaTeclaPresionada;
	//Reproduce un sonido

	public void Playthesound()
		{
            
			Audio.pitch=audioSpeed*0.8f;
	   		if (true){if (!Audio.isPlaying){Audio.Play();}}
	   		else{Audio.Stop();}

	    }

    void Start()
		{
			rb= gameObject.GetComponent<Rigidbody>();
			Audio= GetComponent<AudioSource>();
			
		}

    void Update()
		{

            // Debug.Log("me muevo a " + rb.velocity);
			if (Input.GetKey("w"))
				{
					rb.AddForce(transform.forward*constanteFuerza, ForceMode.VelocityChange);
				}
            if(Input.GetKey("a"))
				{
				    rb.AddForce(transform.right*-constanteFuerza, ForceMode.VelocityChange);
                    rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, -constanteRotacion, 0) * Time.deltaTime));
				}  
            if(Input.GetKey("s"))
				{
					rb.AddForce(-transform.forward*constanteFuerza , ForceMode.VelocityChange);
				}      
            if(Input.GetKey("d"))
				{
					rb.AddForce(transform.right*constanteFuerza, ForceMode.VelocityChange);
                    rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, constanteRotacion, 0) * Time.deltaTime));
				}


			if(Input.GetKeyDown("space"))
                {
                  rb.AddForce(new Vector3(0,5,0) , ForceMode.VelocityChange);
                }


            rb.velocity = Vector3.ClampMagnitude(rb.velocity, constanteVelocidadMaxima);



		}
}
