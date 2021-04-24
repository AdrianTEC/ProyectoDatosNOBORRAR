using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCursosFollower : MonoBehaviour{
    public RectTransform transf;
    
    private void Start(){
    }

    void Update(){
        var screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }
}
