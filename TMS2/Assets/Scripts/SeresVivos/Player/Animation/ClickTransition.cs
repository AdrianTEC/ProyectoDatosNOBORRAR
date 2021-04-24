using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTransition : Transition
{
    private float entryTime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        confirmedNext = false;
        entryTime = Time.time;
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(confirmedNext) return;
        
        float currentPercentage = 100*(Time.time - entryTime) / stateInfo.length;
        if (currentPercentage > 90)
        {
            setValues(animator, true);
            return;
        }
        
        
        if (Input.GetMouseButtonDown(0))
        {
            setValues(animator,false);    
            confirmedNext = true;
        }
     
        
        
    }


}
