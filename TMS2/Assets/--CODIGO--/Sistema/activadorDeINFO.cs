using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activadorDeINFO : MonoBehaviour
{


    private GameObject  canva;
    private Dialogues dialogo;
    public bool UseDialogues= true;
    void Start()
    {
        canva=gameObject.transform.GetChild(0).gameObject;
        dialogo=gameObject.GetComponent<Dialogues>();
    }

    void OnTriggerEnter(Collider other)
        {
                if(other.gameObject.tag=="Player" && !canva.activeSelf)
                    {
                            canva.SetActive(true);
                            if(UseDialogues)
                                {
                                    dialogo.Next();
                                }
                            //other.gameObject.GetComponent<Movimiento>().;
                    }
        }
    void OnTriggerExit(Collider other)
        {
                    if(other.gameObject.tag=="Player" && canva.activeSelf)
                    {
                            canva.SetActive(false);
     
                            //other.gameObject.GetComponent<Movimiento>().;
                    }
        }
}
