using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Death : MonoBehaviour
{
    public  abstract void  act();
    public bool canDie = true;

    private void Awake(){
        canDie = true;

    }

  
}
