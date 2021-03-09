using System.Collections;
using System.Collections.Generic;
using _Scripts._Generales;
using UnityEngine;

public class SlowDown : MonoBehaviour , ExtraBehavior
{

    
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    void Update() {
        Time.timeScale += (1.0f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);


    }
    public void DoSlowmotion ()
    {
        Time.timeScale = slowdownFactor;
       
    }
    public void act(){
        DoSlowmotion();
    }
}
