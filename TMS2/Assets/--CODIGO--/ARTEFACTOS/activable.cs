using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activable : MonoBehaviour
{

    public string IDENTIFICADOR;
    private Animator animator;
    public bool activo;
    public bool fijo=false;
    public bool ESTADO_POR_DEFECTO;
    public bool anteriormenteManipulado= false;
    public bool resuelto=false;

    void Start()
    {
            animator= gameObject.GetComponent<Animator>();
            animator.SetBool("estado",activo);
    }    
    public void refresh()
        {
            animator.SetBool("estado",activo);

        }
    public void alternar()
        {
            animator.SetBool("canIanimate",true);

            if(fijo)    
                {
                    if (!anteriormenteManipulado&&!resuelto)
                        {
                            activo= !activo;
                            animator.SetBool("estado",activo);
                            resuelto=true;
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
