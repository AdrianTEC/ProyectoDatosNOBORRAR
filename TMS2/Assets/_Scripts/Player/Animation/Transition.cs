using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : StateMachineBehaviour
{
    public bool confirmedNext;
    public string parameter;
    private int value;
    public int setValue;
    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        confirmedNext = false;
        value = animator.GetInteger(parameter);
        animator.SetInteger(parameter, 0);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if( !confirmedNext)
                animator.SetInteger(parameter, setValue);
            confirmedNext = true;
        }
     
        
    }
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if(!confirmedNext)
            animator.SetInteger("Attack", 0);
        confirmedNext = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
