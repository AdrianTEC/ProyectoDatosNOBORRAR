using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorDeEquipos : MonoBehaviour
{
    public List<GameObject> objetosExistentes;


    public GameObject dame(string nombre)
        {
                foreach(GameObject arma in objetosExistentes)
                    {
                            if (arma.GetComponent<Pickable>().nombre==nombre)
                                {

                                        return arma;

                                }                        
                    }
                return null;
        }



}
