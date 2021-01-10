using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : StateMachineBehaviour
{
    public bool confirmedNext;

    public List<AnimationParameter< bool>> Booleans;
    public List<AnimationParameter< int>> Integers;
    public List<AnimationParameter< float>> Floats;
    
    

    public void setValues(Animator animator,bool reset)
    {
        if(!reset)
        {
            foreach (var param in Booleans)
                animator.SetBool(param.Parameter, param.Value);
            foreach (var param in Integers)
                animator.SetInteger(param.Parameter, param.Value);
            foreach (var param in Floats)
                animator.SetFloat(param.Parameter, param.Value);
        }
        else
        {
            foreach (var param in Booleans)
                animator.SetBool(param.Parameter, param.DefaultValue);
            foreach (var param in Integers)
                animator.SetInteger(param.Parameter, param.DefaultValue);
            foreach (var param in Floats)
                animator.SetFloat(param.Parameter, param.DefaultValue);
        }
    } 
    
    
}
[Serializable]
public struct AnimationParameter<T> 
{
    public string Parameter;
    public T Value;
    public T DefaultValue;
}