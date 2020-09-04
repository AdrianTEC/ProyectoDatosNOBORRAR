using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogues : MonoBehaviour
{


    public List<string> frases ;
    public TextMeshProUGUI textDisplay;
    public string[] oraciones;
    private GameObject  canva;
    private AudioSource audioS;
    public AudioClip speakSound;
    private int index=0;
    public float velocidad;

    public bool canIpass=true;
     
    void Start()
        {
            canva=gameObject.transform.GetChild(0).gameObject;
            audioS=gameObject.GetComponent<AudioSource>();
        }
    IEnumerator type()
        {
            canIpass=false;
            foreach(char letra in oraciones[index].ToCharArray())
                {
                    textDisplay.text +=letra;
                    audioS.PlayOneShot(speakSound);
                    yield return new    WaitForSeconds(velocidad);

                }
            canIpass=true;
            

        }
    public void Next()
        {
            if(canIpass)
                {
                    if(index < oraciones.Length )
                        {
                            textDisplay.text="";
                            StartCoroutine(type());
                            index++;

                        }
                    else
                        {
                            textDisplay.text="";
                            index=0;
                            canva.SetActive(false);
                        }

                }

        }


}
