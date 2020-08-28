using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniDetector : MonoBehaviour
{
    
    private Palanca  palanca;

    void Update()
    {
            if(Input.GetKeyDown("e")&& palanca!=null)
                {
                    palanca.alternar();
                    
                }        
    }

    private void OnTriggerEnter(Collider other) 
        {       
               if(other.gameObject.tag=="palanca")
                {
                        palanca= other.gameObject.GetComponent<Palanca>();

                } 
        }
 
    void OnTriggerStay(Collider other)
    {
                       if(other.gameObject.tag=="palanca")
                         {
                        palanca= other.gameObject.GetComponent<Palanca>();

                         } 
    }
    void OnTriggerExit(Collider other)
        {
            palanca=null;
                    
        }
}
