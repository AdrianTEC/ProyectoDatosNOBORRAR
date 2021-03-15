using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Generales;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeleeBehavior : MonoBehaviour, ComposedCollider{
    public string[] attacks;
    public string[] defenses;

    public bool antiBullets;
    public bool lookAtTarget = true;
    private Animator animator;
    public float attackRate=1;
    private bool attacking;
    private bool canAttack=true;
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

    /// <summary>
    /// Verifica si se sigue en estado de ataque
    /// </summary>
    /// <param name="obj"></param>
    void attack(GameObject obj){
        verifyIfAtacking();
        if(attacking || !canAttack) return;
        attacking = true;
        canAttack = false;
        
        Invoke(nameof(canAttackAgain),attackRate);
        if(lookAtTarget)
            transform.LookAt(obj.transform);
        int rNumber = Random.Range(0, attacks.Length);
        
        currentAnim = attacks[rNumber];
        animator.Play(currentAnim);
    }

    public void canAttackAgain(){
        canAttack = true;
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
        if (antiBullets && col.CompareTag("Bullet"))
            skipBullet(col.gameObject);
    }

    public void tellAboutExitCollision(Collider col){
        
    }

    public void tellAboutCollision(Collision col){
        if(col.transform.CompareTag("Player"))
            attack(col.gameObject);
        if (col.transform.CompareTag("Bullet"))
            skipBullet(col.gameObject);
    }
}
