using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    public  string tipo;
    public  Vector3 localPosition;
    public Vector3 localRotation;
    private Rigidbody rb;
    private BoxCollider boxCollider;
    public string lugar;
    void Start()
        {
            rb  =gameObject.GetComponent<Rigidbody>();
            boxCollider=gameObject.GetComponent<BoxCollider>();

        }
    void OnCollisionEnter(Collision other)
        {
                if(other.gameObject.tag=="Player")
                    {

                        other.gameObject.GetComponent<Equipamiento>().EquiparObjeto(gameObject,localPosition,localRotation,lugar);
                        rb.useGravity=false;
                        rb.isKinematic=true;
                        if(tipo.Equals("s")|| tipo.Equals("i"))
                        {
                            boxCollider.enabled=false;
                        }

                    }
        }

}
