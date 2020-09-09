using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCamara : MonoBehaviour
{   
    public GameObject target;
    private GameObject mycam;
    public int velocidad;
    private Camera myCamComponent;
    void Start()
        {
            mycam= gameObject.transform.GetChild(0).gameObject;
            myCamComponent= mycam.GetComponent<Camera>();
        }
    void Update()
    {   

            /*
            if(cosa==null)
                {
                    mycam.transform.RotateAround(target.transform.position, this.transform.up,Input.GetAxis("Mouse X")*speed);
                    mycam.transform.LookAt(target.transform);

                }
                else
                    {
                        mycam.transform.RotateAround(cosa.transform.position, this.transform.up,Input.GetAxis("Mouse X")*speed);
                        mycam.transform.LookAt(cosa.transform);
                        
                    }

*/          
        if(target!=null)    {
            mycam.transform.LookAt(target.transform.position);


            if(Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                            mycam.transform.Translate(-Vector3.forward *velocidad* Time.deltaTime, Space.Self);
                }

            if(Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    
                            mycam.transform.Translate(Vector3.forward *velocidad* Time.deltaTime, Space.Self);
                }
        }


    }

}
