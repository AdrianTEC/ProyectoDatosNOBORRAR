using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventario : MonoBehaviour
{
    public List<GameObject> ArmasyHerramientas= new List<GameObject>();
    public List<GameObject> items= new List<GameObject>(); 
    public List<GameObject> coleccionables= new List<GameObject>(); 
    public bool inventarioAbierto=false;
    public GameObject canva;
    public GameObject item;
    private GameObject contenido;
    private GameObject menu;


    private void Start() 
        {
                
        }
    public void mostrarLista()
        {
            foreach( GameObject x in ArmasyHerramientas)
            {
                Debug.Log(x); 
            }
        }
    public void add(GameObject thing)
        {
            ArmasyHerramientas.Add(thing);
        }

    private void Update() 
        {
		    if(Input.GetKeyDown(KeyCode.Escape))
                {
                        if(!inventarioAbierto)
                            {
                                    abrirInventario();
                                    inventarioAbierto=true;
                            }
                        else
                            {
                                    cerrarInventario();
                                    inventarioAbierto=false;
                            }
                }
        }

    private void abrirInventario()
        {
            menu =Instantiate(canva);
            contenido= menu.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

            foreach(GameObject thing in ArmasyHerramientas)
                {

                    GameObject por_agregar = Instantiate(item);

                    Pickable data=thing.GetComponent<Pickable>();
                    por_agregar.transform.GetChild(0).gameObject.GetComponent<Text>().text= data.nombre;
                    por_agregar.transform.GetChild(1).gameObject.GetComponent<Image>().sprite=data.icon;
                    por_agregar.transform.SetParent(contenido.transform);


                }
            Time.timeScale = 0.0f;
        }
    private void cerrarInventario()
        {   
            Destroy(menu);
            Time.timeScale = 1.0f;
        }
}
