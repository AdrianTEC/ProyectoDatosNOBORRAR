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
        _following.MaxAproach = MaxAproach;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) > MaxAproach) 
            _following.WalkTo(WalkSpeed);
        else
        {
            _following.WalkTo(0);
        }
        
    }
}
