using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{

    private IA intel;
    
    void Start()
    {
        intel= gameObject.transform.parent.GetComponent<IA>();
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) 
        {
            
                if(other.gameObject.tag=="Player"&& intel.Target==null)
                    {       
                        
                            intel.Target=other.gameObject;

                    }



        }

}
