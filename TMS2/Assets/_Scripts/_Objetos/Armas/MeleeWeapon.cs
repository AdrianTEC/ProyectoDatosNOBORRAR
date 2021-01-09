using System;
using UnityEngine;

namespace _Scripts._Objetos.Armas
{
    public class MeleeWeapon : Weapon
    {
        public GameObject slash;
        public GameObject hitParticle;
        private Collider _collider;
        public Transform hitPosition;
        public bool DettectCollisions { set; get; }
        

        public override void Attack()
        {
            GameObject tempSlash=Instantiate(slash);

            tempSlash.transform.position = hitPosition.position;
            tempSlash.transform.forward = hitPosition.forward;
            tempSlash.transform.rotation = hitPosition.rotation;
          

        }

        private void OnTriggerEnter(Collider other)
        {
            if(!DettectCollisions||other.CompareTag("Player")) return;
            Instantiate(hitParticle).transform.position = hitPosition.position;
            DamageInteractuable dmi = other.GetComponent<DamageInteractuable>();
            if (dmi!=null)
            {
                dmi.recibeImpact(damage);
            }

        }

   
    }
}
