using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipamiento : MonoBehaviour
{
    private GameObject manoderecha;
    private GameObject manoizquierda;


    void Start()
        {
            manoderecha  = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
            manoizquierda  = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;

        }

    public void EquiparObjeto(GameObject objeto,Vector3 posicion,Vector3 rotacion,string lugar)
        {

            if(lugar.Equals("mderecha"))
                {
                    objeto.transform.SetParent(manoderecha.transform);
                    objeto.transform.localPosition= new Vector3( posicion.x,posicion.y,posicion.z);
                    objeto.transform.localEulerAngles=rotacion;
                }
            if(lugar.Equals("mizquierda"))
                {
                    objeto.transform.SetParent(manoizquierda.transform);
                    objeto.transform.localPosition= new Vector3( posicion.x,posicion.y,posicion.z);
                    objeto.transform.localEulerAngles=rotacion;
                }
            if(lugar.Equals("inventario")||lugar==null)
                {

                }


            //objeto.transform.position= manoderecha.transform.position;

        }
}
