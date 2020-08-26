using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{

      private Vector3 posicion;

      private void Start() 
        {
                posicion= gameObject.transform.GetChild(0).transform.position;
        }
      void OnTriggerEnter(Collider otro)
        {   
            //Debug.Log("hola");
            if(otro.gameObject.tag=="Player")
                { 
                  //  Debug.Log("colision");
                    otro.gameObject.transform.position=posicion;
                }
        }
}
