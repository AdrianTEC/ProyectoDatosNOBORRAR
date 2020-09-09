using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{


    private Animator anim;
    private puzzles manager;
    private bool anteriormenteManipulado= false;

    public  bool RealmenteManipulada=false;

    public bool activo;
    public activable target;
    public bool fijo;
    void Start()
        {
            if(target==null)
                {
                        manager=gameObject.transform.parent.GetComponent<puzzles>();
                }
            anim= gameObject.GetComponent<Animator>();


        }

    public void informar()
        {
            if (RealmenteManipulada)
                {
                    if(target!=null)
                        {
                            target.alternar();
                        }
                    else
                        {
                            if(anteriormenteManipulado)
                                {
                                    manager.decrement();
                                }
                        }
                }
        
                    

        }

    public void alternar()
    {
      
        if(!fijo)
            {
                if(target!=null)
                {
                    activo=!activo;
                    anim.SetBool("estado",activo);

                }

            }
        else
            {
                if(!anteriormenteManipulado)
                    {
                        anteriormenteManipulado=true;
                        activo=true;
                        anim.SetBool("estado",true);
                    }

            }
            
    }
}
