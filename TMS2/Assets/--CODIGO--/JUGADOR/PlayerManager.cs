using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    
    public GameObject jugadorActual;

    public GameObject pato;
    public GameObject mono;

    public bool isTheDuck;
    public RotacionCamara camara;
    

    public void Load(Vector3 pos1, Vector3 pos2)
        {
            pato.transform.position= pos1;
            mono.transform.position= pos2;
        }
    public Vector3[] CurrentPositions()
        {
            return new [] {pato.transform.position , mono.transform.position};
        }
    void Start()
        {   
            pato  =gameObject.transform.GetChild(0).gameObject;
            mono  =gameObject.transform.GetChild(1).gameObject;
            if(mono.activeSelf&&pato.activeSelf)
                {
                    pato.GetComponent<ScriptManager>().establecerCompanero(mono);
          
                    mono.GetComponent<ScriptManager>().establecerCompanero(pato);
                }
            if(!pato.activeSelf)
                {
                    isTheDuck=false;
                }
            camara=gameObject.transform.GetChild(2).gameObject.GetComponent<RotacionCamara>();
            if(isTheDuck)
                {
                    jugadorActual=mono;
                    currentPlayer(pato);
                }
            else
                {
                    jugadorActual=pato;
                    currentPlayer(mono) ;
                }

        }   

    public void Stop(bool estado)
        {
            pato.GetComponent< Movimiento>().Inventario=estado;
            mono.GetComponent< Movimiento>().Inventario=estado;

        }
    public void currentPlayer(GameObject jugador)
        {       
                // Se desactivan las principales caracteristicas y se convierte en un bot
                if(jugadorActual!=null)
                    {
                        if(jugadorActual.activeSelf) 
                            {
                               jugadorActual.GetComponent<ScriptManager>().setToBot();
                            }

                    }

                jugador.GetComponent<ScriptManager>().setToPlayer();

                jugadorActual=jugador;

                camara.target=jugadorActual;
        }
    void Update()
        {
                if(Input.GetKeyDown( KeyCode.Tab))
                    {
                        if(mono!=null&&pato!=null)
                            {

                                    isTheDuck=!isTheDuck;
                                    if(isTheDuck)
                                        {
                                            currentPlayer(pato);
                                        }
                                    else
                                        {
                                            currentPlayer(mono) ;
                                        }

                            }
         
                    }        
        }
}
