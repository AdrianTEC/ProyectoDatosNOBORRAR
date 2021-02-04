using System.Collections.Generic;
using UnityEngine;

namespace _Scripts._Generales{
    public class ActivateOnTrigger : MonoBehaviour{
        public List<GameObject> targets;

        private void Start(){
            foreach (GameObject target in targets){
                target.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other){
            if (!other.CompareTag("Player")) return;
            foreach (GameObject target in targets){
                target.SetActive(true);
            }
        }
    }
}
