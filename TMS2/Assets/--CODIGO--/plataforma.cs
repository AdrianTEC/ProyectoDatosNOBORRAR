using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
    {

    public activable target;

    private puzzles manager;

    private bool activo=false;


        void Start()
        {
            if(target==null)
                {
                        manager=gameObject.transform.parent.GetComponent<puzzles>();
                }

        }

 
        void OnTriggerEnter(Collider other)
            {
                
                if(other.gameObject.tag=="bloque")
                    {
                        activo=true;
                            manager.decrement();

                    }



            }

        void OnTriggerExit(Collider other)
        {
                   if(other.gameObject.tag=="bloque")
                    {
                        activo=false;
                            manager.increment();

                    }
        }
    }
