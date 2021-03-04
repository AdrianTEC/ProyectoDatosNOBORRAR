using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour , IDamageInteractuable
{
    public GameObject residuo;
    public int expForce;
    
    public void BreakRock()
    {
        var res=Instantiate(residuo);
        res.transform.position = transform.position;

        Destroy(gameObject);

    }

    public void recibeImpact(int damage,attackTypes attacktype)
    {
        BreakRock();
    }
    
}
