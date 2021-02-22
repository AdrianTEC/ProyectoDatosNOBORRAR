using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableManual : Activable{
    public List<GameObject> toActivate;
    public List<GameObject> toDesactivate;

    public override void setActive(bool state){
    }

    public override void switchState(){
        active = !active;
        foreach (var obj in toActivate){
            obj.SetActive(active);
        }
        foreach (var obj in toDesactivate){
            obj.SetActive(active);
        }
    }
}
