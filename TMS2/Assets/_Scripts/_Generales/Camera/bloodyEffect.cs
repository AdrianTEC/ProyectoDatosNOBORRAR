using System.Collections;
using System.Collections.Generic;
using _Scripts._Generales;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class bloodyEffect : MonoBehaviour , ExtraBehavior{
    public Volume volume;
    public void act(){
        volume.enabled = true;
        Invoke(nameof(disableVolume),0.3f);        
    }

    public void disableVolume(){
        volume.enabled = false;
    }
}
