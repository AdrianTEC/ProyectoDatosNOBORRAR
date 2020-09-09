using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehavior : MonoBehaviour
{
    public List<  MeshRenderer  > objetos;
    public void ocultar()
        {
            foreach(MeshRenderer x in objetos)
                {
                    x.enabled=false;
                }
        }
    public void mostrar()
        {
            foreach(MeshRenderer x in objetos)
                {
                    x.enabled=true;
                }
        }
}
