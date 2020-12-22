using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public GameObject  destino;
    
    public Animator anim;
    

    void Start()
        {
            anim=gameObject.GetComponent<Animator>();
        }
    public void hide(bool siOno)
        {
            anim.SetBool("hide",siOno);
        }
     void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag=="Player")
                {
                    other.gameObject.transform.position=destino.transform.position;
    
                    

                }


            
        }



    
}
