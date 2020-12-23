using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public List<GameObject> Players; 
    public List<Equipment>  PlayersEQUIPMENT; 
    void Start()
    {
        Players= GameObject.FindGameObjectsWithTag("Player").ToList();
        PlayersEQUIPMENT = getComponentInList<Equipment>(Players);
    }

    public List<T> getComponentInList<T>(List<GameObject> list)
    {    
        var response=new List<T>();
        foreach (var VARIABLE in list)
        {
            response.Add(VARIABLE.GetComponent<T>());
        }

        return response;
    }
}    
