using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public GameObject  destino;
    
    public MapBehavior mapaDestino;
    public MapBehavior mapaActual;



     void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag=="Player")
                {
                    other.gameObject.transform.position=destino.transform.position;
                    mapaDestino.mostrar();
                    mapaActual.ocultar();   
                    

                }


            
        }

    
}
