using System;
using UnityEngine;

namespace _Scripts._Objetos.Armas
{
    public class MeleeWeapon : Weapon
    {
        public GameObject slash;
        private Collider _collider;
        public Transform hitPosition;
        
        
        private void Start()
        {
        }

        public override void Attack()
        {
            GameObject tempSlash=Instantiate(slash);

            tempSlash.transform.position = hitPosition.position;
            tempSlash.transform.rotation = hitPosition.rotation;

        }
    
    


    }
}
