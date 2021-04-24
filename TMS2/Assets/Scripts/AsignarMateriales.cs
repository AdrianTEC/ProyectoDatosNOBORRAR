
using UnityEditor;
using UnityEngine;


public class AsignarMateriales : MonoBehaviour
{
    public GameObject[] Lista;
    public Material mat;
    public string dir="Assets/_Prefabs/Construction/BLOCKS/";

    public string apodo;

    public GameObject CubePREFAB;
    public enum MyEnum
    {
        asignarMaterial,
        ConvertirAPrefab,
        corregirNombre,
        normalizarTamano
    }

    public MyEnum action;
    public void Awake()
    {
        if(action==MyEnum.asignarMaterial)
            asignarMaterial();
        if(action==MyEnum.ConvertirAPrefab)
            makePrefabs();
        if(action==MyEnum.corregirNombre)
            corregirNombre();
        if (action == MyEnum.normalizarTamano)
            normalizar();

    }

    void normalizar()
    {
        foreach (var VARIABLE in Lista)
        {
            var name = VARIABLE.name;
            VARIABLE.name = "block";

            var Cube = Instantiate(CubePREFAB);
            VARIABLE.transform.parent = Cube.transform;
            Cube.name = name;
            VARIABLE.transform.position=Cube.transform.position;

        }   
    }
   void asignarMaterial()
   {
       int contador = 0;
       foreach (var VARIABLE in Lista)
       {
           VARIABLE.name = apodo + contador;
           contador++;

           VARIABLE.GetComponent<MeshRenderer>().material = mat;


       }      
   }

   void corregirNombre()
   {
       int contador = 0;
       foreach (var VARIABLE in Lista)
       {
           VARIABLE.name = apodo + contador;
           contador++;
       }     
   }
    void makePrefabs()
    {
        foreach (var VARIABLE in Lista)
        {
            
            PrefabUtility.SaveAsPrefabAsset(VARIABLE,dir+ VARIABLE.name +".prefab");
        }    
    }
    
}
