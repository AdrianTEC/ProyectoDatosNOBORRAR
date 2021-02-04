using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class ParticleBullet : MonoBehaviour{
    public int damage;
    public List<string> ignoreTags;
    private void OnParticleCollision(GameObject other){

        

    
        if(other.CompareTag("Untagged") || ignoreTags.Contains(other.tag) ) return;
        IDamageInteractuable damageInteractuable = other.GetComponent<IDamageInteractuable>();
        if (damageInteractuable!=null){
            damageInteractuable.recibeImpact(damage);            
        }
    }
}
