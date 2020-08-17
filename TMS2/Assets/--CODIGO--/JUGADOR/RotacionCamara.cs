using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCamara : MonoBehaviour
{   
    private GameObject myGameObj;
    private int speed=2;
    void Start()
        {
            myGameObj= GameObject.Find("PATO");
        }
    void Update()
    {   
            if(Input.GetMouseButton(1)){
                this.transform.RotateAround(myGameObj.transform.position, this.transform.up,-Input.GetAxis("Mouse X")*speed);
            }
    }
}
