using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add the Text
public class boton : MonoBehaviour
{
    private Animator anim;
    private bool press;
    private puzzles manager;
    private string texto;
    public GameObject texpro;
    void Start()
    {
            anim= gameObject.GetComponent<Animator>();
            manager=gameObject.transform.parent.GetComponent<puzzles>();
            texto=texpro.GetComponent<TextMeshPro>().text;
        
    }

    public void resetear()
    {
        press=false;
        anim.SetBool("estado",press);
    }




    void OnTriggerEnter(Collider other)
        {
            if(!press&& other.gameObject.tag=="Player")
                {
            Debug.Log(texto);

                    press=true;
                    anim.SetBool("estado",press);
                    manager.write(texto);
                }
        }
}
