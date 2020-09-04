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
    
    void Start()
        {   
            pato  =gameObject.transform.GetChild(0).gameObject;
            mono  =gameObject.transform.GetChild(1).gameObject;

            pato.GetComponent<ScriptManager>().establecerCompanero(mono);
            mono.GetComponent<ScriptManager>().establecerCompanero(pato);

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
                       jugadorActual.GetComponent<ScriptManager>().setToBot();

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
