using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCamara : MonoBehaviour
{   
    private GameObject myGameObj;
    private int speed=2;
     private Vector3 offset;
    private GameObject mycam;
    public int altura=5;
    private Camera myCamComponent;
    void Start()
        {
            myGameObj= GameObject.Find("PATO");
            mycam= gameObject.transform.GetChild(0).gameObject;
            myCamComponent= mycam.GetComponent<Camera>();
        }
    void Update()
    {   

            if(Input.GetMouseButton(2))
                {
                    this.transform.RotateAround(myGameObj.transform.position, this.transform.up,-Input.GetAxis("Mouse X")*speed);
                    mycam.transform.Rotate(this.transform.rotation.x-Input.GetAxis("Mouse Y")*speed*2, 0.0f, 0.0f, Space.Self);
                }


            if(Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    if(this.transform.position.y+ altura< myGameObj.transform.position.y +30)
                    {
                        myCamComponent.fieldOfView+=1;
                        altura+=3;
                    }
                }

            if(Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    if(this.transform.position.y+altura > myGameObj.transform.position.y)
                     {
                        myCamComponent.fieldOfView-=1;
                        altura-=3;
                     }
                }

            this.transform.position= myGameObj.transform.position+new Vector3(0,altura,0);


    }

}
