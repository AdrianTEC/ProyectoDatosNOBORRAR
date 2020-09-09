using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniDetector : MonoBehaviour
{
    
    private Palanca  palanca;
    private cofres cofre;

    void Update()
    {
            if(Input.GetKeyDown("e")&& palanca!=null)
                {
                    palanca.RealmenteManipulada=true;
                    palanca.alternar();
                    
                }        
            if(Input.GetKeyDown("e")&& cofre!=null)
                {
                    cofre.abrir();
                }         
    }

    private void OnTriggerEnter(Collider other) 
        {       
               if(other.gameObject.tag=="palanca")
                {
                        palanca= other.gameObject.GetComponent<Palanca>();

                } 
                if(other.gameObject.tag=="cofre")
                {
                        cofre= other.gameObject.GetComponent<cofres>();

                } 
        }
 
    void OnTriggerStay(Collider other)
    {
                       if(other.gameObject.tag=="palanca")
                         {
                        palanca= other.gameObject.GetComponent<Palanca>();

                         } 
                        if(other.gameObject.tag=="cofre")
                        {
                                cofre= other.gameObject.GetComponent<cofres>();

                        }  
    }
    void OnTriggerExit(Collider other)
        {
            if(palanca!=null)
                {
                    palanca.RealmenteManipulada=false;
                    palanca=null;
                    
                }
            cofre=null;
                    
        }
}
