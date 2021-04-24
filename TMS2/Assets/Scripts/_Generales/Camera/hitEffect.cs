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
    public float SlowDownLenght=0.1f;

    private void Start(){
        GameObject hiteffect= GameObject.FindGameObjectWithTag("hiteffect");
        slowDown = hiteffect.GetComponent < SlowDown>();
        cameraShake = hiteffect.GetComponent<CameraShake>();
        blood = hiteffect.GetComponent<bloodyEffect>();
    }

    public void act(){
        slowDown.act();
        slowDown.slowdownLength = SlowDownLenght;
        cameraShake.act();
        if(useScreenBlood)
            blood.act();
        if (animator!=null){
            animator.SetLayerWeight(1, 1);
            animator.Play("injured",1);
            Invoke(nameof(removeAttackCondition),.5f);
            
        }
    }

    public void removeAttackCondition(){
        animator.SetLayerWeight(1, 0);
    }


}
