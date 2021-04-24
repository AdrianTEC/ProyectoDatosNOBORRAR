using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummieSpinShooter : MonoBehaviour{

    public float velocity;
    public string obj;
    public int maxShoots;
    public float timeBetweenShoots;
    
    void Start()
    {
        GetComponent<Rigidbody>().AddTorque(transform.forward*velocity);    
        InvokeRepeating(nameof(shoot),.1f,timeBetweenShoots);
    }

    public void shoot(){
        maxShoots--;
        if(maxShoots<=0) Destroy(gameObject);
        GameObject instance = ObjectPooler.SharedInstance.GetPooledObject(obj);
        if (instance == null) return;

        instance.transform.position = transform.position;
        instance.transform.forward = transform.up;
        instance.SetActive(true);
        
    }
}
