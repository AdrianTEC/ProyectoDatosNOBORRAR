using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Generales;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeleeBehavior : MonoBehaviour, ComposedCollider{
    public string[] attacks;
    public string[] defenses;

    public float attackRate;
    public bool antiBullets;
    public string antiBulletAttack;
    public Vector3 offset;
    public float attackDistance;
    private Animator animator;
    
    private bool attacking;
    private string currentAnim;
    
    void Start(){
        animator = GetComponent<Animator>();
    }

    void verifyIfAtacking(){
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(currentAnim)){
            attacking = false;
            currentAnim = "";
        }
    }

    void attack(GameObject obj){
        verifyIfAtacking();
        if(attacking) return;
        attacking = true;
        transform.LookAt(obj.transform);
        int rNumber = Random.Range(0, attacks.Length);
        
        currentAnim = attacks[rNumber];
        animator.Play(currentAnim);
    }
    void skipBullet(GameObject obj){
        verifyIfAtacking();
        if(attacking) return;
        transform.LookAt(obj.transform);
        int rNumber = Random.Range(0, defenses.Length);
        animator.Play(defenses[rNumber]);
    }
    public void tellAboutCollision(Collider col){
        if(col.CompareTag("Player"))
            attack(col.gameObject);
        if (col.CompareTag("Bullet"))
            skipBullet(col.gameObject);
    }

    public void tellAboutCollision(Collision col){
        if(col.transform.CompareTag("Player"))
            attack(col.gameObject);
        if (col.transform.CompareTag("Bullet"))
            skipBullet(col.gameObject);
    }
}
