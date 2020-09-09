using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codigoParaCambiodecuadro : MonoBehaviour
{
    public CuadroMovil manager;
    public void heyThere(bool estado)
        {
            Debug.Log(estado);
            manager.MoverCuadro(estado);
        }

}
