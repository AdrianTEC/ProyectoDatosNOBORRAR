using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    private Animator _animator;
    private Following _following;
    
    public GameObject Target;
    public float MaxAproach;
    public float WalkSpeed;
    public bool canFollow;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _following = GetComponent<Following>();

        _following.canFollow = canFollow;
        _following.Target = Target;
        _following.WalkSpeed = WalkSpeed;
        _following.MaxAproach = MaxAproach;
    }

    void Update()
    {
        
    }
}
