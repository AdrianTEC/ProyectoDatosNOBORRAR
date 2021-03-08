using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class enemyDamageBox : MonoBehaviour{
   public int damage;

   private void OnTriggerEnter(Collider other){
      if (other.CompareTag("Player"))
         other.GetComponent<IDamageInteractuable>().recibeImpact(damage, attackTypes.cortante);
   }
}
