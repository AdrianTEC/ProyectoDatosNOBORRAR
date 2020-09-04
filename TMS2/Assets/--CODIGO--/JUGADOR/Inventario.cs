using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventario : MonoBehaviour
{
    public List<GameObject> ArmasyHerramientas= new List<GameObject>();
    public List<GameObject> coleccionables= new List<GameObject>(); 
    public List<GameObject> items= new List<GameObject>(); 
    public bool inventarioAbierto=false;
    private attackPoint puntoDeAtaque;
    private GameObject CurrentPlayer;
    private GameObject manoizquierda;
    private GameObject manoderecha;
    private Movimiento movimiento;
    private GameObject contenido;
    private audioManager audiom;
    private PlayerManager admin;
    public GameObject canva;
    private GameObject menu;
    public GameObject item;
	private Animator Anim;



    private void Start() 
        {
    	    Anim=gameObject.GetComponent<Animator>();
            movimiento= gameObject.GetComponent<Movimiento>();
            audiom= gameObject.GetComponent<audioManager>();
            admin=gameObject.GetComponent<PlayerManager>();
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

            CurrentPlayer = admin.jugadorActual;

                manoderecha    = CurrentPlayer.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
                manoizquierda  = CurrentPlayer.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;

            admin.Stop(true);//Aviso que he abierto el inventario
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

                Vector3[] posRot= CurrentPlayer.GetComponent<HandlerDefinitions>(). PosAndRotaOf(data.nombre);

                Vector3 posicion = posRot[0];
                Vector3 rotacion = posRot[1];
   
            if(data.lugar.Equals("md"))
                {

                    Weapon weapon=  thing.GetComponent<Weapon>();          

                    if(manoderecha.transform.childCount!=0)
                        {
                            manoderecha.transform.GetChild(0).gameObject.SetActive(false);
                            manoderecha.transform.GetChild(0).gameObject.transform.SetParent(null);
                        }
                    thing.transform.SetParent(manoderecha.transform);
               
         
                            thing.transform.localPosition= new Vector3( posicion.x,posicion.y,posicion.z);
                            thing.transform.localEulerAngles=rotacion;

                    puntoDeAtaque=CurrentPlayer.transform.GetChild(1).gameObject.GetComponent<attackPoint>();

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
   
    
                }



	}    
    private void cerrarInventario()
        {   
            Destroy(menu);
            Time.timeScale = 1.0f;
            admin.Stop(false);//Aviso que he abierto el inventario

        }

    public void RecogerObjeto(GameObject thing,string lugar)
        {
            audiom.PickUp();
            add(thing);
         
            thing.SetActive(false);        


            if(lugar.Equals("inventario")||lugar==null)
                {

                }


            //thing.transform.position= manoderecha.transform.position;

        }    



}
