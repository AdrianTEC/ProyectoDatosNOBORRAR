using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{	
	private Rigidbody rb;
    private float FuerzaActual;
	private float constanteFuerza=0.5f;
    public float constanteRotacion=300;
	private int  constanteVelocidad =5;
    private float  VelocidadMaximaActual;
	private Animator Anim;
	private bool usingShield=false;
	public int constanteSaltos=3;
	private int actualSaltos=0;
	public bool Inventario=false;

	private Vector3 before_position;

	public bool apuntando= false;
	//Reproduce un sonido



    void Start()
		{
			rb= gameObject.GetComponent<Rigidbody>();
    	    Anim=gameObject.GetComponent<Animator>();
			VelocidadMaximaActual=constanteVelocidad;
			FuerzaActual=constanteFuerza;
		}

    void Update()

		{
			# region  WASD
			before_position=transform.position;
			Debug.Log(before_position);
            // Debug.Log("me muevo a " + rb.velocity);
			if ((Input.GetKey("w")||Input.GetKey("a")||Input.GetKey("s")||Input.GetKey("d")))
				{
/**		<-------------------------------------Para W ------------------------------------------------------> 	*/
					if (Input.GetKey("w"))  //-->Arriba
						{
							if(!usingShield)
									{

										rb.AddForce(transform.forward*FuerzaActual, ForceMode.VelocityChange);
									}
								else
									{
										rb.AddForce(transform.forward*FuerzaActual*2/3, ForceMode.VelocityChange);

									}

						}
/**		<-------------------------------------Para A ------------------------------------------------------> 	*/

					if(Input.GetKeyDown("a")&&Input.GetKey(KeyCode.LeftShift))
							{
								

										rb.AddForce(-transform.right*15,ForceMode.VelocityChange);
										rb.AddForce(transform.up*3,ForceMode.VelocityChange);


							}	
			
					if(Input.GetKey("a")&&!Input.GetKey(KeyCode.LeftShift))//--> izquierda
						{

							if(!apuntando)
								{
										if(!usingShield)
											{
												rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, -constanteRotacion, 0) * Time.deltaTime));
											}
										else
											{
												rb.AddForce(transform.right*FuerzaActual*2/-3, ForceMode.VelocityChange);
											}
								}
							else	
								{
										rb.AddForce(transform.right*FuerzaActual*-1, ForceMode.VelocityChange);

								}

						}  



/**		<-------------------------------------Para S------------------------------------------------------> 	*/

					if(Input.GetKey("s"))//-->abajo
						{
								if(!usingShield)
									{
										rb.AddForce(transform.forward*-FuerzaActual, ForceMode.VelocityChange);
									}
								else
									{
										rb.AddForce(transform.forward*-FuerzaActual*2/3, ForceMode.VelocityChange);

									}
						}      
/**		<-------------------------------------Para d ------------------------------------------------------> 	*/
					if(Input.GetKeyDown("d")&&Input.GetKey(KeyCode.LeftShift))
						{
										rb.AddForce(transform.right*15,ForceMode.VelocityChange);
										rb.AddForce(transform.up*3,ForceMode.VelocityChange);
						}

					if(Input.GetKey("d")&&!Input.GetKey(KeyCode.LeftShift))//-->derecha
						{
							if(!apuntando)
								{

								
									if(!usingShield)
										{ 
											rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, constanteRotacion, 0) * Time.deltaTime));
										}
									else
										{
											rb.AddForce(transform.right*FuerzaActual*2/3, ForceMode.VelocityChange);
										}
								}
							else	
								{
										rb.AddForce(transform.right*FuerzaActual, ForceMode.VelocityChange);
								}
					
						}
			        Anim.SetBool("caminando",true);
				}

			else
				{
					Anim.SetBool("caminando",false);
				}
		#endregion 

/**		<-------------------------------------Para ESPACIO ------------------------------------------------------> 	*/

			if(Input.GetKeyDown("space")&&!Input.GetKey("a"))
                {
					salto();
                }



			////////////////////////////////////////////////////////////////////////


	        if(Input.GetMouseButtonDown(0)&&!Inventario)
				{
						Anim.SetBool("ataque",true);
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
				Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * 1000, Color.red);
						Anim.SetBool("volando",true);
					
				}
			Debug.Log("posicion despues: "+gameObject.transform.position);
		}	

	void salto()
		{
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
