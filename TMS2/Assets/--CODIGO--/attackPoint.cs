using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPoint : MonoBehaviour
{
    
    public int dano;
    public int empuje;

    private Animator anim;

    void Start()
    {
        anim= gameObject.transform.parent.GetComponent<Animator>();        
    }
    void OnTriggerEnter(Collider otro)
        {
            if(otro.gameObject.tag=="enemy")
                {

                        Vida vida=otro.gameObject.GetComponent<Vida>();
                        vida.propulsar(this.transform.forward,empuje);
                        //Debug.Log(anim.GetBool("volando"));
                        if(anim.GetBool("volando"))
                            {
                                vida.restarHP(dano*2);
                            }
                        else
                            {
                                 vida.restarHP(dano);
                            }
                }
            try 
                {
                    Rigidbody rigidbody= otro.gameObject.GetComponent<Rigidbody>();
                     rigidbody.AddForce(transform.forward*empuje,ForceMode.VelocityChange);
                }    
                catch{}
        }
  
}
