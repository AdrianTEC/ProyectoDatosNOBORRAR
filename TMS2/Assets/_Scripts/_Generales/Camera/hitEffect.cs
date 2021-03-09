using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Generales;
using _Scripts._Generales.Camera;
using UnityEngine;

public class hitEffect : MonoBehaviour, ExtraBehavior{
    private SlowDown slowDown;
    private CameraShake cameraShake;
    private bloodyEffect blood;
    public bool useScreenBlood;
    public Animator animator;

    private void Start(){
        GameObject hiteffect= GameObject.FindGameObjectWithTag("hiteffect");
        slowDown = hiteffect.GetComponent < SlowDown>();
        cameraShake = hiteffect.GetComponent<CameraShake>();
        blood = hiteffect.GetComponent<bloodyEffect>();
    }

    public void act(){
        slowDown.act();
        cameraShake.act();
        if(useScreenBlood)
            blood.act();
        if (animator ) animator.Play("injured");
    }


}
