using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Space_EnemyMovement : MonoBehaviour{

    public float distanceFromTarget=70;
    public float smoothTime=2.30f;
    public float yOffset=2;
    private Vector3 velocity = Vector3.zero;
    private Transform target;
    private IA_DistaceAttack iaDistaceAttack;
    
    void Start(){
        target = GameObject.FindWithTag("Player").transform;
        
    }

    void Update(){
        if(target==null) return;
        Transform parent = target.parent;
        Vector3 targetPos = parent.position +parent.forward*distanceFromTarget+parent.up*yOffset;
        transform.position= Vector3.SmoothDamp(transform.position,targetPos, ref velocity, smoothTime);

    
    }

   
    
}
