using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlay : Transition
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            setValues(animator,false);
    }
}
