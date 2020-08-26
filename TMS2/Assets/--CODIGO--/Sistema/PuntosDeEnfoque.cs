using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosDeEnfoque : MonoBehaviour

{


    private Transform padre;
    private GameObject camara;


    void Start()
    {
        padre= gameObject.transform.parent.transform;
        camara= GameObject.Find("Container");
    }

    public void moveCamHere()
        {
            camara.transform.position=padre.position;
            camara.transform.rotation=padre.rotation;
        }

    void OnTriggerStay(Collider other)
        {
            if(other.gameObject.tag=="Player")
                {
                        moveCamHere();
                }


            
        }

}
