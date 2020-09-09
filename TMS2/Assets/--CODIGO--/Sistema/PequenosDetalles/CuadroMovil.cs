using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadroMovil : MonoBehaviour
{

    private GameObject  canva;
    private Dialogues dialogo;
    public RectTransform trans;
    
    GUARDADO guardadoManager;
    private bool currentButton=true;
    void Start()
    {
        canva=gameObject.transform.GetChild(0).gameObject;
        dialogo=gameObject.GetComponent<Dialogues>();
        guardadoManager=gameObject.transform.parent.GetComponent<GUARDADO>();
    }
    void Update()
        {
            if(Input.GetKey("a")||Input.GetKey(KeyCode.LeftArrow))
                {
                    MoverCuadro(true);
                }
            
            if(Input.GetKey("d")||Input.GetKey(KeyCode.RightArrow))
                {
                    MoverCuadro(false);
                }
            if(Input.GetKey(KeyCode.Return))
                {

                    enviar();

                }
        }   

    public void enviar()
        {
            if(!currentButton)
                {
                    canva.SetActive(false);
                    guardadoManager.Save();
                    Time.timeScale = 1f;
                }
            else
                {
                    canva.SetActive(false);
                    Time.timeScale = 1f;
                }
        }
    public void MoverCuadro(bool estado)
        {

            if(estado)
                {
                    currentButton=true;
                    trans.anchoredPosition3D= new Vector3(-310,-10,0);

                }
            else
                {
                    currentButton=false;
                    trans.anchoredPosition3D= new Vector3(327,-10,0);
                }



        }
    void OnTriggerEnter(Collider other)
        {
                if(other.gameObject.tag=="Player" && !canva.activeSelf)
                    {       Time.timeScale = 0f;

                            canva.SetActive(true);
                    
                    }
        }

}
