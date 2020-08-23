using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCamara : MonoBehaviour
{   
    private GameObject myGameObj;
    private int speed=5;
     private Vector3 offset;
    private GameObject mycam;
    public int altura=5;
    public int velocidad;
    private Camera myCamComponent;
    void Start()
        {
            myGameObj= GameObject.Find("PATO");
            mycam= gameObject.transform.GetChild(0).gameObject;
            myCamComponent= mycam.GetComponent<Camera>();
        }
    void Update()
    {   

            mycam.transform.RotateAround(myGameObj.transform.position, this.transform.up,Input.GetAxis("Mouse X")*speed);


            // BAJA O SUBE LA CAMARA
            /*
            if(Input.GetMouseButton(2))
                {
                    Debug.Log(mycam.transform.position );
                    if(Input.GetAxis("Mouse Y")<0 && mycam.transform.position.y -5 > myGameObj.transform.position.y)
                        {
                            mycam.transform.Translate(-Vector3.up *velocidad* Time.deltaTime, Space.World);

                        }
                  if(Input.GetAxis("Mouse Y")>0 && mycam.transform.position.y -30 < myGameObj.transform.position.y)
                        {
                            mycam.transform.Translate(Vector3.up *velocidad* Time.deltaTime, Space.World);

                        }
                }
                */

            if(Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    if(this.transform.position.y+ altura< myGameObj.transform.position.y +30)
                    {
                            mycam.transform.Translate(-Vector3.forward *velocidad* Time.deltaTime, Space.Self);
                    }
                }

            if(Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    if(this.transform.position.y+altura > myGameObj.transform.position.y)
                     {
                            mycam.transform.Translate(Vector3.forward *velocidad* Time.deltaTime, Space.Self);
                     }
                }
            mycam.transform.LookAt(myGameObj.transform);

            this.transform.position= myGameObj.transform.position+new Vector3(0,altura,0);


    }

}
