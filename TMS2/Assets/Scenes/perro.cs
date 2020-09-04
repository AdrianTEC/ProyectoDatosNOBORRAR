using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perro : MonoBehaviour
{
    
    public int velocidad ;
    public string nombre;
    



    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKey("w"))
            {
                transform.Translate(transform.forward*velocidad);
            }
        if(Input.GetKey("s"))
            {
                transform.Translate(-transform.forward*velocidad);

            }
        if(Input.GetKey("a"))
            {
                 transform.Translate(-transform.right*velocidad);


            }
        if(Input.GetKey("d"))
            {
                transform.Translate(transform.right*velocidad);

            }         
        if(Input.GetKey("space"))
            {
                transform.Translate(transform.up*velocidad);

            }                            
    }


}
