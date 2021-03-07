using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyShatter : MonoBehaviour{
    public List<Rigidbody> pieces;
    public float impluse;
    
    void Start()
    {
        foreach (var piece in pieces){
            piece.useGravity = true;
            piece.AddForce(new Vector3(Random.Range(-10,10),Random.Range(-10,10),Random.Range(-10,10))* impluse);
        }
    }

   
}
