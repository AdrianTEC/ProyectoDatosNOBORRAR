using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRotator : MonoBehaviour{
    public float speed;

    private float maxPressHeight;
    private int currentRotation;
    private float[] rotations ={0, 90, 180, 270};
    private bool canRotate;
    void Update()
    {
        if(canRotate) 
            transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, rotations[currentRotation], 0), speed);
    }

    private void OnTriggerEnter(Collider other){
        if(!other.CompareTag("Player")) return;
        canRotate = true;
        currentRotation++;
        if (currentRotation > 3)
            currentRotation = 0;
    }

    private void OnTriggerExit(Collider other){
        if(!other.CompareTag("Player")) return;
        canRotate = false;
    }
}
