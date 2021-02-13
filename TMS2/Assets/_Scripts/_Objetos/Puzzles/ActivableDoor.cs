using UnityEngine;

public class ActivableDoor : Activable{

    public Vector3 openPosition;
    public float smoothTime;
    private Transform target;
    private Vector3 velocity = Vector3.zero;
    public override void setActive(bool state){
        active = state;
    }

    private void Start(){
        target = transform.GetChild(0);
    }

    private void Update(){
        if (active)
            target.localPosition = Vector3.SmoothDamp(target.localPosition, openPosition, ref velocity, smoothTime);
        else 
            target.localPosition = Vector3.SmoothDamp(target.localPosition, Vector3.zero, ref velocity, smoothTime);
    }       


}
