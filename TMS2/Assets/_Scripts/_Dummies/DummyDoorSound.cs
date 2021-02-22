using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDoorSound : MonoBehaviour{
    public GameObject door;
    private AudioSource audioSource;
    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject == door){
            audioSource.Play();
        }
    }
}
