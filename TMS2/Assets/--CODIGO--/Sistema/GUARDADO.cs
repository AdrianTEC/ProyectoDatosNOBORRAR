using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

public class GUARDADO : MonoBehaviour
{

    //private Inventario inventario;
    public List<activable> puzzles;
    public List<bool> puzzles_bool;    
    public List<cofres> cofrecitos;
    public List<bool> cofrecitos_bool;


    public List<GameObject> enemigos;
    public List<bool> enemigosVivos;
/*

    EasyFileSave myFile;
    void Start()
        {
                GameObject manager=GameObject.FindWithTag("PLAYER_MANAGER");
                    playerManager= manager.GetComponent<PlayerManager>();
                    inventario=  manager.GetComponent<Inventario>();
                    myFile = new EasyFileSave();
                    
                    foreach(cofres cofre in cofrecitos)
                        {
                            cofrecitos_bool.Add(true);
                        }
                    foreach(activable x in puzzles)
                        {
                            puzzles_bool.Add(false);
                        }
                    foreach(GameObject x in enemigos)
                        {
                            enemigosVivos.Add(true);
                        }
        }

    public void Save()
        {
            Vector3[] posiciones =playerManager.CurrentPositions();
            myFile.Add("player1", new Vector3(posiciones[0].x,posiciones[0].y,posiciones[0].z));
            myFile.Add("player2",  new Vector3(posiciones[1].x,posiciones[1].y,posiciones[1].z));
            myFile.AddBinary("weapons",inventario.weapons);

            for(int i =0; i < cofrecitos.Count; i++)
                {
                    if(cofrecitos[i].abierto)
                        {
                            cofrecitos_bool[i]=false;
                        }
                    else
                        {
                            cofrecitos_bool[i]=true;
                        }
                }
            for(int i =0; i < puzzles.Count;i++)
                {
                    if(puzzles[i].resuelto)
                        {
                            puzzles_bool[i]=true;
                        }
                    else
                        {
                            puzzles_bool[i]=false;
                            
                        }
                }
            for(int i =0; i < enemigos.Count;i++)
                {
                    if(enemigos[i].activeSelf)
                        {
                            enemigosVivos[i]=true;
                        }
                    else
                        {
                            enemigosVivos[i]=false;
                            
                        }
                }
            myFile.AddBinary("cofres",cofrecitos_bool);
            myFile.AddBinary("puzzles",puzzles_bool);
            myFile.AddBinary("enemigos",enemigosVivos);
            myFile.Save();
        }
    public void Load()
        {
            myFile.Load();

            playerManager.Load(myFile.GetUnityVector3("player1"),myFile.GetUnityVector3("player2"));
            inventario.weapons =(List<string>)myFile.GetBinary("weapons");
            cofrecitos_bool = (List<bool>)myFile.GetBinary("cofres");
            puzzles_bool = (List<bool>)myFile.GetBinary("puzzles");
            enemigosVivos=(List<bool>)myFile.GetBinary("enemigos");
            for(int i =0; i < cofrecitos.Count; i++)
                {
                    if(!cofrecitos_bool[i])
                        {
                            cofrecitos[i].cantidad=0;
                        }


                }

            for(int i =0; i < puzzles.Count; i++)
                {
                    if(puzzles_bool[i])
                        {
                            puzzles[i].resuelto=true;
                            puzzles[i].activo=!puzzles[i].ESTADO_POR_DEFECTO;
                            puzzles[i].anteriormenteManipulado= true;
                            puzzles[i].refresh();
                        }
                    else
                        {
                            puzzles[i].resuelto=false;

                        }
                   

                }
           
            for(int i=0; i< enemigos.Count;i++)
                {
                    if(enemigosVivos[i])
                        {
                            enemigos[i].GetComponent<IA>().devolver();
                        }
                    else
                        {
                            enemigos[i].SetActive(false);
                        }

                }

        }
    public void Update()
        {
            if(Input.GetKeyDown("l"))
                {
                    Load();
                }
            if(Input.GetKeyDown("k"))
                {
                    Save();
                }

        }
        */
}
