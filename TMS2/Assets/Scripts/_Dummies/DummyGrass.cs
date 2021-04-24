using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyGrass : MonoBehaviour{
    public Vector3 scaleTarget;
    public float smooth;
    private Vector3 nextTarget;
    private void OnTriggerEnter(Collider other){
        
    }

    public void changeScale(){
        transform.localScale = Vector3.Lerp(transform.localScale,nextTarget,smooth);
    }
    
    private void OnTriggerExit(Collider other){
        transform.localScale = new Vector3(1, 1, 1);
    }
}
