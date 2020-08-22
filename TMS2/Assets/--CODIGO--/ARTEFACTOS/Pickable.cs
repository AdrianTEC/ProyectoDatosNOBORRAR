using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickable : MonoBehaviour
{

    public  string tipo;
    public string nombre;
    public string description;
    public  Vector3 localPosition;
    public Vector3 localRotation;
    private Rigidbody rb;
    private BoxCollider boxCollider;
    public string lugar;
    public Sprite icon;
    public bool picked;

    //tipos pueden ser
    // sw sh l k i
    // espada escudo lanza llave item
    void Start()
        {

            picked=false;

            rb  =gameObject.GetComponent<Rigidbody>();
            boxCollider=gameObject.GetComponent<BoxCollider>();
            
        }
    void OnCollisionEnter(Collision other)
        {
        
                if(other.gameObject.tag=="Player" &&!picked)
                    {
                        picked=true;
                        Inventario inventario= other.gameObject.GetComponent<Inventario>();

                        inventario.RecogerObjeto(gameObject,localPosition,localRotation,lugar);

                        //inventario.mostrarLista();

                        rb.useGravity=false;
                        rb.isKinematic=true;
                  
                            boxCollider.enabled=false;

                    }
        }

}
