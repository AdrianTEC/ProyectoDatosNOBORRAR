using System;
using UnityEngine;

namespace _Scripts._Objetos.Armas
{
    public class MeleeWeapon : Weapon
    {
        public GameObject slash;
        private Collider _collider;
        public Transform hitPosition;
        public GameObject hitParticle;

        public bool DettectCollisions { set; get; }
        

        public override void Attack()
        {
            //GameObject tempSlash=Instantiate(slash);
            //tempSlash.transform.parent = transform;
            //tempSlash.transform.position = hitPosition.position;
            //tempSlash.transform.forward = hitPosition.forward;
            slash.SetActive(true);
        }

        public void stopAttack(){
            slash.SetActive(false);

        }
        private void OnCollisionEnter(Collision other){
            if(DettectCollisions)
                Instantiate(hitParticle).transform.position =other.contacts[0].point;

        }
    }
}
