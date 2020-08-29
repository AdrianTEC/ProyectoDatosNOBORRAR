using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
    {

    public activable target;

    private puzzles manager;



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
                            manager.decrement();

                    }



            }

        void OnTriggerExit(Collider other)
        {
                   if(other.gameObject.tag=="bloque")
                    {
                            manager.increment();

                    }
        }
    }
