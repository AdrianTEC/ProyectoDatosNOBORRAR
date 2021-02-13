using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public abstract class Electrical: MonoBehaviour{
    public bool active;
    public bool fountain;
    protected bool hasSendSignal;
    public MeshRenderer target;
    public Material offMaterial;
    public Material onMaterial;
    public abstract void sendSignal();
    public abstract void setState(bool state);

    public abstract void turnOff();
}