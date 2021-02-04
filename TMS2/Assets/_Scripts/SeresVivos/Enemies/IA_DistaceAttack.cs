using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class IA_DistaceAttack : MonoBehaviour{

    public Transform pointer;
    public float shootTime    = 1.0f;
    public float targetOffset = 2.0f;
    public GameObject attack;
    public GameObject holder;
    public bool partOfOneBigger;
    private Transform player;
    private bool canShoot =true;
    private List<Transform> dots;

    private void Start(){
        player = GameObject.FindWithTag("Player").transform;
    }
    private void OnEnable(){
        InvokeRepeating("shoot",shootTime,shootTime);
    }
    private void OnDisable(){
        CancelInvoke();
    }
    private void shoot(){
        transform.LookAt(player.transform.position);
        if (Vector3.Dot(transform.forward, player.forward)>-0.90F) return;
            
        if(!canShoot) return;
        canShoot = false;
        if (player == null) return;
        
        
        GameObject bullet= Instantiate(attack);
        bullet.transform.position = pointer.position;
        bullet.transform.forward = pointer.forward;
            Invoke(nameof(canShootAgain), shootTime);

    }

  

    private void canShootAgain(){
        canShoot = true;
    }

    private void OnDestroy(){
        
        if(partOfOneBigger ){
            holder.GetComponent<ComposedEnemy>().reduceChilds();
        }
        Destroy(transform.parent.gameObject);
    }
}
