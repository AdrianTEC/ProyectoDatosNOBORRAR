using System;
using UnityEngine;

namespace _Scripts._Generales{
    public class childCollider : MonoBehaviour{
        public GameObject FatherObj;
        private ComposedCollider Father;

        private void Start(){
            Father = FatherObj.GetComponent<ComposedCollider>();
        }

        private void OnTriggerEnter(Collider other){
            Father.tellAboutCollision(other);
        }

        private void OnCollisionEnter(Collision other){
            Father.tellAboutCollision(other);
        }

        private void OnTriggerStay(Collider other){
            Father.tellAboutCollision(other);

        }
    }
}