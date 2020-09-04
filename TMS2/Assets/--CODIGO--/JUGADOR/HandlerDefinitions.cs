using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HandlerDefinitions : MonoBehaviour
{
    public bool needsCorrection;

    public List<def> LISTA = new List<def>();


    public Vector3[] PosAndRotaOf(string nombre)
        {
            for(int i =0 ;i < LISTA.Count;i++)
                {
                    if(LISTA[i].objeto== nombre)
                        {
                                Vector3[] response= new Vector3[] {LISTA[i].posicion , LISTA[i].rotacion };
                                return response;
                        }
                }
            return null;
        }    

}
[Serializable] 
public struct def
{
        public Vector3 posicion;
        public Vector3 rotacion;

        public string objeto;
}