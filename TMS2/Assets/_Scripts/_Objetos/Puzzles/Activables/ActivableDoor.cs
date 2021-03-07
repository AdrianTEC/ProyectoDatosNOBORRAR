using UnityEngine;

namespace _Scripts._Objetos.Puzzles.Activables{
    public class ActivableDoor : Activable{

        public Vector3 openPosition;
        public float smoothTime;
        private Transform target;
        private Vector3 velocity = Vector3.zero;


        public override void setActive(bool state){

            active = state;
        }

        public override void switchState(){
            setActive(!active);
        }

        private void Start(){
            target = transform.GetChild(0);
        }

        public void moveDoor(Vector3 dir){
            target.localPosition = Vector3.SmoothDamp(target.localPosition, dir, ref velocity, smoothTime);

        }
        private void Update(){
            if (active){
                moveDoor(openPosition);
            }
            else 
                moveDoor(Vector3.zero);

        }       


    }
}
