using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour, Interacuable{
    public float speed;

    private float maxPressHeight;
    private int currentRotation;
    private float[] rotations ={0, 90, 180, 270};
    private bool rotating;
    private AudioSource audioSource;

    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        if(!rotating) return;


        if(Math.Abs(transform.rotation.eulerAngles.y  - rotations[currentRotation]) > 0.1f){
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rotations[currentRotation], 0),
                speed);
        }
        else{
            rotating = false;
        }
    }




    public void interactuar(){
        if (rotating) return;
        audioSource.Play();
        currentRotation++;
        rotating = true;

        if (currentRotation > 3)
            currentRotation = 0;
    }
}
