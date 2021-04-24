using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricInteracter :Electrical{
    public List<Activable> targets;
    public override void sendSignal(){
        if(hasSendSignal) return;;
        hasSendSignal = true;
        setState(true);
        
  
    }

    public override void setState(bool state){
        if(fountain) return;
        active = state;
        target.material = active ? onMaterial : offMaterial;
        foreach (Activable target in targets){
            target.setActive(state);                
        }
    }

    public override void turnOff(){  
        if(!fountain) setState(false);
        hasSendSignal = false;
    }
}
