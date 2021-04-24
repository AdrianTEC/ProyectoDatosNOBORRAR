using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalWire : Electrical
{

    [Header("electrical Things")]

    [Header("display Things")]

    public List<Electrical> relations=new List<Electrical>();

    public override void sendSignal(){
        if(hasSendSignal) return;;
        hasSendSignal = true;
        setState(true);
        foreach (Electrical node in relations){
            if(node.fountain) continue;
            node.sendSignal();
        }
    }

    public override void setState(bool state){
            if(fountain) return;
            active = state;
            target.material = active ? onMaterial : offMaterial;
    }

    public override void turnOff(){
        if(!fountain) setState(false);
        hasSendSignal = false;

    }

    private void OnTriggerStay(Collider other){
        if (other.CompareTag("electrical")){
            if(!active) return;
            Electrical info = other.GetComponent<Electrical>();
            if(!relations.Contains(info))
                relations.Add(info);
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.CompareTag("electrical")){
            Electrical info = other.GetComponent<Electrical>();
            
            relations.Remove(info);
        }
    }
}
