using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour , BulletInteractuable
{
    public GameObject residuo;
    public int expForce;
    
    public void BreakRock()
    {
        var res=Instantiate(residuo);
        res.transform.position = transform.position;
        foreach (Transform VARIABLE in res.transform)
        {
            Vector3 dir= new Vector3(Random.Range(-1, 1),Random.Range(-1, 1),Random.Range(-1, 1))*expForce;
           VARIABLE.GetComponent<Rigidbody>().AddForce(dir*expForce,ForceMode.VelocityChange);
        }
        Destroy(gameObject);

    }

    public void recibeImpact()
    {
        BreakRock();
    }
}
