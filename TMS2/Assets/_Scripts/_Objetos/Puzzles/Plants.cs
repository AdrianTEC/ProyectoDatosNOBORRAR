using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class Plants : MonoBehaviour, IDamageInteractuable{
    public Rigidbody rigidbody;
    public Animator animator;
    public AudioSource audioSource;


    public void recibeImpact(int damage, attackTypes attacktype){
        if (attacktype == attackTypes.cortante){
      
            if(audioSource)
                audioSource.Play();
            if(animator){
                transform.rotation= Quaternion.Euler(Random.Range(0,360),transform.eulerAngles.y,Random.Range(0,360));
                animator.enabled = false;
            }
          
                rigidbody.constraints = RigidbodyConstraints.None;
                rigidbody.useGravity = true;
                rigidbody.AddTorque(transform.forward*2000);
                rigidbody.GetComponent<Collider>().enabled = false;
                Invoke(nameof(disapear),1); 
        }
    }

    public void disapear(){
        Destroy(gameObject);
    }
}
