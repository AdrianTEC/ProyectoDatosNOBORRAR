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
	private Animator Anim;
    public bool needCorrection;
    private GameObject manoderecha;
    private GameObject manoizquierda;
    private Movimiento movimiento;
    private attackPoint puntoDeAtaque;
    private void Start() 
        {
            manoderecha  = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
            manoizquierda  = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
 
    	    Anim=gameObject.GetComponent<Animator>();
            movimiento= gameObject.GetComponent<Movimiento>();
            puntoDeAtaque=this.gameObject.transform.GetChild(1).gameObject.GetComponent<attackPoint>();


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
            movimiento.Inventario=true;//Aviso que he abierto el inventario
            menu =Instantiate(canva);
            contenido= menu.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

            foreach(GameObject thing in ArmasyHerramientas)
                {

                    GameObject por_agregar = Instantiate(item);

                    Pickable data=thing.GetComponent<Pickable>();
                    por_agregar.transform.GetChild(0).gameObject.GetComponent<Text>().text= data.nombre;
                    por_agregar.transform.GetChild(1).gameObject.GetComponent<Image>().sprite=data.icon;
                    por_agregar.transform.GetChild(2).gameObject.GetComponent<Text>().text= data.description;

                    por_agregar.transform.SetParent(contenido.transform);
                    Button btn = por_agregar.GetComponent<Button>();
                    btn.onClick.AddListener(() => {equipar(thing); });

                }
            Time.timeScale = 0.0f;
        }


    void equipar(GameObject thing){
		//Debug.Log (data.nombre);
            thing.SetActive(true);
            Pickable data=thing.GetComponent<Pickable>();
            Vector3 posicion =data.localPosition;
            Vector3 rotacion = data.localRotation;
             Vector3 posicion2 =data.localPosition2;
            Vector3 rotacion2 = data.localRotation2;           
            if(data.lugar.Equals("md"))
                {



                    Weapon weapon=  thing.GetComponent<Weapon>();              
                    if(manoderecha.transform.childCount!=0)
                        {
                            manoderecha.transform.GetChild(0).gameObject.SetActive(false);
                            manoderecha.transform.GetChild(0).gameObject.transform.SetParent(null);
                        }
                    thing.transform.SetParent(manoderecha.transform);
                    if(!needCorrection)
                        {
                            thing.transform.localPosition= new Vector3( posicion.x,posicion.y,posicion.z);
                            thing.transform.localEulerAngles=rotacion;
                        }
                    else       
                        {
                            thing.transform.localPosition= new Vector3( posicion2.x,posicion2.y,posicion2.z);
                            thing.transform.localEulerAngles=rotacion2;
                        }

                    Anim.SetInteger("tipo",weapon.tipo);


                    //cambio los valores del arma
                    puntoDeAtaque.empuje=weapon.empuje;
                    puntoDeAtaque.dano=weapon.dano;
    

                }


            if(data. lugar.Equals("mi"))
                {
                    if(manoizquierda.transform.childCount!=0)
                        {
                            manoizquierda.transform.GetChild(0).gameObject.SetActive(false);
                            manoizquierda.transform.GetChild(0).gameObject.transform.SetParent(null);
                        }
                    thing.transform.SetParent(manoizquierda.transform);
               if(!needCorrection)
                        {
                            thing.transform.localPosition= new Vector3( posicion.x,posicion.y,posicion.z);
                            thing.transform.localEulerAngles=rotacion;
                        }
                    else       
                        {
                            thing.transform.localPosition= new Vector3( posicion2.x,posicion2.y,posicion2.z);
                            thing.transform.localEulerAngles=rotacion2;
                        }
                }



	}    
    private void cerrarInventario()
        {   
            Destroy(menu);
            Time.timeScale = 1.0f;
            movimiento.Inventario=false;
        }

    public void RecogerObjeto(GameObject thing,Vector3 posicion,Vector3 rotacion,string lugar)
        {

            add(thing);
         
            thing.SetActive(false);        


            if(lugar.Equals("inventario")||lugar==null)
                {

                }


            //thing.transform.position= manoderecha.transform.position;

        }    



}
