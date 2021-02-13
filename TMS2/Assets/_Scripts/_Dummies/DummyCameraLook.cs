using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCameraLook : MonoBehaviour
{
    void Start(){
        transform.forward = Camera.main.transform.forward;
    }

}
