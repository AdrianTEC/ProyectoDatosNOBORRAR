using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntable : MonoBehaviour
{

    private GameObject apuntador;
    private bool activado=false;
    void Start()
        {

            apuntador=gameObject.transform.GetChild(1).gameObject;

        }

    public void alternar(bool estado)
        {
            activado=estado;
            apuntador.SetActive(activado);

        }

}
