using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class IA_DistaceAttack : MonoBehaviour{

    public Transform pointer;
    public float shootTime    = 1.0f;
    public float targetOffset = 2.0f;
    public float maxDistance  = 100f;
    
    
    public float patrolSize;
    public FormationTypes generationPatrol=FormationTypes.Single;
    public GameObject specialattack;

    private Transform player;
    private bool canShoot = true;
    private List<Transform> dots;

    private void Start(){
        player = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("shoot",shootTime,shootTime);
    }


    public void prepareShoot(){
        transform.LookAt(player.position+player.forward*targetOffset);
        shoot();
    }

    private void shoot(){
        
        if(!canShoot) return;
        canShoot = false;
        transform.LookAt(player.transform.position);
        
        switch (generationPatrol){
            case FormationTypes.Sphere:
                FormationController.sphereFormation(10,(int) patrolSize,7,"EnemyBullet2",transform);
                break;
            case FormationTypes.Triangle:
                FormationController.triangleFormation(10,"EnemyBullet2",transform,2);
                break;
            case FormationTypes.Spin:
                GameObject rotador= Instantiate(specialattack);
                rotador.transform.position = transform.position;
                rotador.transform.up = transform.forward;
                break;
            case FormationTypes.Single:
                directShoot();
                break;
        }
        Invoke(nameof(canShootAgain), shootTime);

    }


    private void directShoot(){
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("EnemyBullet");
        if (bullet != null){
            Transform transform1 = pointer.transform;
            bullet.transform.position = transform1.position;
            bullet.transform.forward = transform1.forward;
            bullet.SetActive(true);
        }

    }
    
    private void canShootAgain(){
        canShoot = true;
    }
    
}
