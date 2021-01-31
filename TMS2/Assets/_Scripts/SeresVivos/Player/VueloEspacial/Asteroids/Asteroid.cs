using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour , DamageInteractuable
{
    public GameObject residuo;
    public int expForce;
    
    public void BreakRock()
    {
        var res=Instantiate(residuo);
        res.transform.position = transform.position;

        Destroy(gameObject);

    }

    public void recibeImpact(int damage)
    {
        BreakRock();
    }
    
}
