using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AdministradorDeEscenas : MonoBehaviour
{

        public void cargarEscena(string escena )
            {   
                  SceneManager.LoadScene(escena);
            }

}
