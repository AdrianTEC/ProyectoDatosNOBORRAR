using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosDeEnfoque : MonoBehaviour

{


    private Transform padre;
    private GameObject camara;
    private GameObject cam;

    void Start()
    {
        padre= gameObject.transform.parent.transform;
        camara= GameObject.Find("Container");
        cam=camara.transform.GetChild(0).gameObject;
    }

    public void moveCamHere()
        {
            camara.transform.position=padre.position;
            cam.transform.localPosition=new Vector3(0,0,0);
            cam.transform.localEulerAngles=new Vector3(0,0,0);

            
            camara.transform.rotation=padre.rotation;
        }

    void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag=="Player")
                {
                        moveCamHere();
                }


            
        }

}
