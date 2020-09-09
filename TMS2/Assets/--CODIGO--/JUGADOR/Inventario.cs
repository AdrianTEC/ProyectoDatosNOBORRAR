using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventario : MonoBehaviour
{
    public List<GameObject> coleccionables= new List<GameObject>(); 
    public List<GameObject> items= new List<GameObject>(); 
    public List<string> weapons= new List<string>();
    private ManejadorDeEquipos instanceManager;
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
            instanceManager=gameObject.GetComponent<ManejadorDeEquipos>();
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
                      foreach(string nombre in weapons)
                        {

                            GameObject por_agregar = Instantiate(item);//SE INSTANCIA UNA CASILLA

                            GameObject thing = instanceManager.dame(nombre);

                            Pickable data=thing.GetComponent<Pickable>();//SE OBTIENE SU INFORMACION

                            por_agregar.transform.GetChild(0).gameObject.GetComponent<Text>().text= data.nombre;
                            por_agregar.transform.GetChild(1).gameObject.GetComponent<Image>().sprite=data.icon;
                            por_agregar.transform.GetChild(2).gameObject.GetComponent<Text>().text= data.description;

                            por_agregar.transform.SetParent(contenido.transform);
                            Button btn = por_agregar.GetComponent<Button>();
                            btn.onClick.AddListener(() => {equipar(thing); });

                        }

            Time.timeScale = 0.0f;
        }
    void equipar(GameObject prefab){

            GameObject thing=Instantiate(prefab);

            Pickable data=thing.GetComponent<Pickable>();
                data.modoEQUIPADO();

                Vector3[] posRot= CurrentPlayer.GetComponent<HandlerDefinitions>(). PosAndRotaOf(data.nombre);

                Vector3 posicion = posRot[0];
                Vector3 rotacion = posRot[1];
   
            if(data.lugar.Equals("md"))
                {

                    Weapon weapon=  thing.GetComponent<Weapon>();          

                    if(manoderecha.transform.childCount!=0)
                        {
                           Destroy( manoderecha.transform.GetChild(0).gameObject);
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
                             Destroy( manoizquierda.transform.GetChild(0).gameObject);
                        }
                    thing.transform.SetParent(manoizquierda.transform);
                            thing.transform.localPosition= new Vector3( posicion.x,posicion.y,posicion.z);
                            thing.transform.localEulerAngles=rotacion;
    
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
            //add(thing);
            Pickable  picker = thing.GetComponent<Pickable>();

            weapons.Add(picker.nombre);

            Destroy(thing);

            if(lugar.Equals("inventario")||lugar==null)
                {

                }


            //thing.transform.position= manoderecha.transform.position;

        }    



}
