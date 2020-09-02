using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofres : MonoBehaviour
{

    public GameObject objecto;

    public bool abierto;

    public int cantidad;
    private Animator anim;


    void Start()
        {
            anim = gameObject.GetComponent<Animator>();
        }

    public void Spawnear()
        {

                    for (int i =0; i<cantidad; i++)
                    {
                        GameObject thing=Instantiate(objecto);
                        thing.transform.position= this.transform.position;
                        
                        try 
                            {
                                    thing.GetComponent<Rigidbody>().AddForce(new Vector3(0,2,0) , ForceMode.VelocityChange);;
                            }   
                        catch{}

                    }
        }
    public void abrir()
        {
            if(!abierto)
            {
                abierto=true;
                anim.SetBool("open",true);

            }
        }
    void Update()
        {
            
        }
}
