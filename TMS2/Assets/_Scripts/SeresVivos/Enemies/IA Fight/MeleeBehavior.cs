using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeleeBehavior : MonoBehaviour{
    public string[] attacks;
    public float attackRate;
    public bool antiBullets;
    public string antiBulletAttack;
    private Animator animator;
    
    void Start(){
        animator = GetComponent<Animator>();
        InvokeRepeating(nameof(attack),.1f,attackRate);
    }

    void attack(){
        int rNumber = Random.Range(0, attacks.Length);
        animator.Play(attacks[rNumber]);
    }
}
