using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntado : MonoBehaviour
{

    private List<GameObject> lista;

    public GameObject objetoMasCercano;
    private Movimiento movimiento;
    private Transform ptransform;
    void Start()
        {
            lista=new List<GameObject>();
            movimiento=gameObject.transform.parent.gameObject.GetComponent<Movimiento>();
            ptransform=gameObject.transform.parent.transform;

        }   

    void Update()
        {


            if(Input.GetKeyDown("q"))
                {
                    if(objetoMasCercano!=null)
                        {
                            desapuntar();
                        }
                    else
                        {
                            apuntar();
                        }
                }  
            if(objetoMasCercano!=null)
                {
                    if( objetoMasCercano.GetComponent<Vida>().HP <= 0)
                        {
                            objetoMasCercano.GetComponent<Apuntable>().alternar(false);
                            objetoMasCercano=null;   
                            apuntar();
                        }
                    else
                        {
                            Vector3 lTargetDir = objetoMasCercano.transform.position - ptransform.position;
                            lTargetDir.y = 0.0f;
                            ptransform.rotation = Quaternion.RotateTowards(ptransform.rotation, Quaternion.LookRotation(lTargetDir), Time.time *1);
                            movimiento.apuntando=true;       
                        }
                }
            else
                {
                    movimiento.apuntando=false;        

                }
          

        }   
    public GameObject getMasCercano()
        {
            if(objetoMasCercano==null)
                {
                    return calcularMasCercano();

                }
            else
                {return objetoMasCercano;}
        }
    public GameObject calcularMasCercano()
        {
            if(lista.Count>0)
                    {
                        float distancia=10000;

                        foreach( GameObject objeto in lista)
                            {   
                            
                                if(objeto!=null)
                                    {
                                        float dis =Vector3.Distance (transform.position,objeto.transform.position);
                                        if(dis < distancia )
                                            {
                                                distancia=dis;
                                                objetoMasCercano=objeto;
                                            }
                                    }
                                

                            } 
                            return objetoMasCercano;
                    }
                    else {return null; }
        }
    private void apuntar()
        {       

                lista.RemoveAll(item => item == null);

                if(lista.Count>0)
                    {
                        calcularMasCercano();

                        if(objetoMasCercano.GetComponent<Vida>().HP > 0)    
                            {
                                objetoMasCercano.GetComponent<Apuntable>().alternar(true);
                            }        
                        else
                            {
                                objetoMasCercano=null;
                            }
                    }


        }    
    private void desapuntar()
        {
            if(objetoMasCercano!=null)
                {
                    objetoMasCercano.GetComponent<Apuntable>().alternar(false);
                    objetoMasCercano=null;
                }


        }
    private void OnTriggerEnter(Collider other) 
        {

                    if(other.gameObject.tag=="enemy")
                        {       
                                if(!lista.Contains(other.gameObject))
                                    {
                                        lista.Add(other.gameObject);
                                    }
                        }
             



        }


}
