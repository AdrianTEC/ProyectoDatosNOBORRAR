using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzles : MonoBehaviour
{

    public List<GameObject> activadores;
    public string password;
    public activable target;
    private int cantidadObjetos;

    public string currentText="";

    void Start()
        {
            cantidadObjetos=activadores.Count;   
        }
    public void decrement()
        {
                cantidadObjetos-=1;
                if(cantidadObjetos<=0)
                    {
                        target.alternar();
                    }

        }
        public void increment()
        {

            bool yacumpliaanteslacondicion =cantidadObjetos<=0;

                cantidadObjetos+=1;
                if(yacumpliaanteslacondicion)
                    {
                        target.alternar();
                    }
        }
    public void write(string letra)
        {
            currentText+=letra;

            if(currentText.Equals(password))
                {
                        target.alternar();

                }
            else
                {
                    if (currentText.Length>= password.Length)
                        {
                                Invoke("reiniciar",5);
                        }
                }
        }
    public void reiniciar()
        {
            currentText="";
            foreach( GameObject x in activadores)
                {
                    x.GetComponent<boton>().resetear();
                }
        }

}
