using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicZone : MonoBehaviour{
    public AudioSource sound;
    public float maximunVolume;
    public float fadeOut;
    public float fadeIn;
    public float changeVolumePerFrame = 0.01f;


    private void Start(){
        sound.volume = 0;
    }

    public void increaseVolume(){
        if(sound.volume+changeVolumePerFrame <maximunVolume){
            sound.volume += changeVolumePerFrame;
            Invoke(nameof(increaseVolume),fadeIn);

        }
        else
            sound.volume = maximunVolume;
    }
    public void decreaseVolume(){
        if(sound.volume-changeVolumePerFrame >0){
            sound.volume -= changeVolumePerFrame;
            Invoke(nameof(decreaseVolume),fadeOut);
        }
        else
            sound.volume = 0;


    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player"))
            increaseVolume();
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player"))
            decreaseVolume();
    }
}
