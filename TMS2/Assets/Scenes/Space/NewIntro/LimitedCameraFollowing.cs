using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedCameraFollowing : MonoBehaviour{
    public Transform target;
    public float smoothTime;
    public float Yoffset;
    public float Xoffset;

    public Vector3 positionCorrection;
    
    private Vector3 currVelocity = Vector3.zero;

    void Update()
    {
        //Camera Offset Aplication
        Vector3 pos = transform.localPosition;
        
        Vector3 distance =   target.localPosition -pos;
        distance.z = 0;

        distance += positionCorrection;
        if (Mathf.Abs(distance.x) < Xoffset && distance.y ==0) return;
        
        
        transform.localPosition= Vector3.SmoothDamp (transform.localPosition,pos+distance,ref currVelocity,smoothTime);
    }
}
