using System;
using System.Collections.Generic;
using _Scripts._Generales;
using UnityEditor;
using UnityEngine;


public class IA_DistaceAttack : MonoBehaviour{

    public Transform pointer;
    public float shootTime = 1.0f;
    public float lookAtTargetTime = 0.1f;
    public GameObject attack;
    public bool bulletChildOfOrigin = false;
    public float distanceOffset;
    public bool needFaceTheTarget = true;
    public float attackDistance = 10000;
    private Transform player;
    private bool canShoot =true;
    private List<Transform> dots;

    private void Start(){
        player = GameObject.FindWithTag("Player").transform;
    }
    private void OnEnable(){
        InvokeRepeating("shoot",1,shootTime);
        InvokeRepeating("looAt",1,lookAtTargetTime);
    }
    private void OnDisable(){
        CancelInvoke();
    }

    public void looAt(){
        if(GameInfo.gameIsPaused|| GameInfo.InventoryIsOpen) return;

        var transform1 = player.transform;
        transform.LookAt(transform1.position+ transform1.forward*distanceOffset);
    }
    private void shoot(){
        if(GameInfo.gameIsPaused|| GameInfo.InventoryIsOpen) return;
        
        if(needFaceTheTarget)
            if (Vector3.Dot(transform.forward, player.forward)>-0.90F) return;
            
        if(!canShoot) return;
        if(Vector3.Distance(player.position,transform.position)>attackDistance) return;
        canShoot = false;
        if (player == null) return;
        
        
        GameObject bullet= Instantiate(attack);
        if (bulletChildOfOrigin){
            bullet.transform.parent = pointer.transform;
            bullet.transform.localPosition= Vector3.zero;
            bullet.transform.localRotation = Quaternion.Euler(0,0,0);
        }
        else{
            bullet.transform.position = pointer.position;
            bullet.transform.forward = pointer.forward;
        }

        Invoke(nameof(canShootAgain), shootTime);

    }

  

    private void canShootAgain(){
        canShoot = true;
    }

  
}
