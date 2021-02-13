using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalFountain : MonoBehaviour{
    public List<Electrical> nodes ;
    public float refreshSignalTime;
    public Electrical fountain;
    private void Start(){
        nodes = new List<Electrical>();
        for (int i=0; i< transform.childCount;i++){
            nodes.Add(transform.GetChild(i).transform.GetChild(0).GetComponent<Electrical>());
        }
        
        InvokeRepeating(nameof(sendInpulse),1,refreshSignalTime);
    }

    private void sendInpulse(){
        for (int i = 0; i < nodes.Count; i++){
                nodes[i].turnOff();
        }
        fountain.sendSignal();
    }
}

