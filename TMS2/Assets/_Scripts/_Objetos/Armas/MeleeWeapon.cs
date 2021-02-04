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
            //tempSlash.transform.parent = transform;
            tempSlash.transform.position = hitPosition.position;
            tempSlash.transform.forward = hitPosition.forward;
          

        }

        private void OnTriggerEnter(Collider other)
        {
            if(!DettectCollisions||other.CompareTag("Player")) return;
            Instantiate(hitParticle).transform.position = hitPosition.position;
            IDamageInteractuable dmi = other.GetComponent<IDamageInteractuable>();
            if (dmi!=null)
            {
                dmi.recibeImpact(damage);
            }
            pushOther(other.gameObject);

        }

        private void pushOther(GameObject other)
        {
            Rigidbody rigidbody;

            rigidbody = other.GetComponent<Rigidbody>();
            if (rigidbody)
            {
                rigidbody.AddForce(-transform.forward*pushConstant);
            }

        }
   
    }
}
