using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textoFlotante : MonoBehaviour
{
    
    public float DestroyTime=3f;
    private Vector3 RandomizeIntesity = new Vector3(0.5f,0,0);


    void Update()
    {
		    Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
        
    }

    void Start()
    {
        Destroy(gameObject,DestroyTime);
            
    }

}
