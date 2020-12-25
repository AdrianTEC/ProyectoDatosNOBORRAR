using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TAMANO : MonoBehaviour
{
    public Vector3 pos_Principal;
    public Vector3 escala_Principal;
    public Vector3 pos_Secundaria;
    public Vector3 escala_Secundaria;
    public RectTransform trans;
    public List<Image> STATEICON;
    public GameObject estados;
    private void Start() {
    }



    public void activarEstado(int id)
        {
            STATEICON[id].color= new Color32( 255,255,255,255);
            for(int i =0;i< STATEICON.Count; i++)
                {
                    if(i!=id)
                        {
                            STATEICON[i].color= new Color32( 255,255,255,64);
                        }
                }

        }


    public void ToFront()
        {
            //gameObject.transform.position= pos_Principal;
              trans.anchoredPosition3D=pos_Principal;
              gameObject.transform.localScale=escala_Principal;
              estados.SetActive(false);


        }
    public void ToBack()
        {
           // gameObject.transform.position= pos_Secundaria;
            trans.anchoredPosition3D=pos_Secundaria;
             gameObject.transform.localScale=escala_Secundaria;
             estados.SetActive(true);

        }    
}
