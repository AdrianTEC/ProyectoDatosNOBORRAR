using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activable : MonoBehaviour
{


    private Animator animator;
    public bool activo;
    public bool fijo=false;
    private bool anteriormenteManipulado= false;


    void Start()
    {
            animator= gameObject.GetComponent<Animator>();
            animator.SetBool("estado",activo);
    }

    public void alternar()
        {

            if(fijo)    
                {
                    if (!anteriormenteManipulado)
                        {
                            activo= !activo;
                            animator.SetBool("estado",activo);

                            anteriormenteManipulado=true;
                        }


                }
            else
                {
                    activo=!activo;
                    animator.SetBool("estado",activo);

                }





        }
}
