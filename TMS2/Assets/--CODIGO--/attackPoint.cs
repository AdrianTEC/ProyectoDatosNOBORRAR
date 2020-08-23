using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPoint : MonoBehaviour
{
    
    public int dano;
    public int empuje;


    void Start()
    {
        
    }
    void OnTriggerEnter(Collider otro)
        {
            if(otro.gameObject.tag=="enemy")
                {
                        Vida vida=otro.gameObject.GetComponent<Vida>();
                        vida.propulsar(this.transform.forward,empuje);
                        vida.restarHP(dano);
                }
        }
  
}
