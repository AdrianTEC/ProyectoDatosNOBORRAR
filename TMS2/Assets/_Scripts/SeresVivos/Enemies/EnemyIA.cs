using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Generales;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    private Animator _animator;
    private Following _following;
    
    public GameObject Target;
    public float MaxAproach;

    public float minAproach=15;
    public float walkSpeed;
    public bool canFollow;
    private Player_Manager _playerManager;
    private List<GameObject> players;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _following = GetComponent<Following>();
        players = GameObject.FindGameObjectWithTag("PLAYER_MANAGER").GetComponent<Player_Manager>().Players;
        _following.canFollow = canFollow;
        _following.MaxAproach = MaxAproach;
    }

    void Update()
    {
     
        if( !Target) {
            foreach (var player in players) {
                if (Vector3.Distance(player.transform.position, transform.position) < minAproach) {
                    Target = player;
                    _following.Target = Target;
                    break;
                }
             
            }
            return;
        }

        float distance = Vector3.Distance(transform.position, Target.transform.position);

        if ( distance> MaxAproach&&distance<minAproach) 
            _following.WalkTo(walkSpeed);
        else
        {
            Target = null;
            _following.WalkTo(0);
        }
        
    }

 

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,minAproach);
    }
}
