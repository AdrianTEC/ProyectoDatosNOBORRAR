using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public List<GameObject> Players; 
    public List<Equipment>  PlayersEQUIPMENT;
    public List<Animator> PlayersANIMATOR;
    public InventoryController InvControl;
    
    void Awake()
    {
        Players= GameObject.FindGameObjectsWithTag("Player").ToList();
        PlayersEQUIPMENT = getComponentInList<Equipment>(Players);
        PlayersANIMATOR = getComponentsInChildList<Animator>(Players, 0);
        InvControl = GetComponent<InventoryController>();
    }

    public List<T> getComponentsInChildList<T>(List<GameObject> list,int childNumber)
    {
        List<T> response= new List<T>();
        foreach (GameObject variable in list)
        {
            response.Add(variable.transform.GetChild(childNumber).gameObject.GetComponent<T>());
        }
        return response;
    }
    public List<T> getComponentInList<T>(List<GameObject> list)
    {
        return list.Select(variable => variable.GetComponent<T>()).ToList();
    }
}    
