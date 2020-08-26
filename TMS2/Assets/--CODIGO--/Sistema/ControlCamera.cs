using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{   
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