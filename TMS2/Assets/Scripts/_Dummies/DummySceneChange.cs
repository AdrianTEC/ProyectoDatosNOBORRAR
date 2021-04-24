using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Animator transition;
    public LevelLoader levelLoader;
    public String nextScene;

    
 

    void OnEnable()
    {
     load();   
    }
    
    private void toGameOverScreen(){
        levelLoader.LoadLevelAsync(nextScene);
    }

    public void load()
    {
        transition.Play("Closed");
        float duration;
        duration = transition.GetCurrentAnimatorStateInfo(0).length;
        Invoke(nameof(toGameOverScreen),duration/2);
    }
}
