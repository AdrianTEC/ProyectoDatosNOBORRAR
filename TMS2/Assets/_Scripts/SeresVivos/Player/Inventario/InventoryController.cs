using System;
using _Scripts._Generales;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public InventoryObject inventory;
    public Animator inventoryDisplay;
    private Player_Manager PM;
    private static readonly int Open = Animator.StringToHash("open");

    private void Start()
    {
        PM = GetComponent<Player_Manager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            OpenOrCloseInventory();
    }

    public void AddItem(Item ob, int cuantity)
    {
        inventory.AddItem(ob, cuantity);
    }

    public void OpenOrCloseInventory()
    {
        bool newstate = !inventoryDisplay.GetBool(Open);
        inventoryDisplay.SetBool(Open,newstate);
        //! hay que considerar el current player, solo para pruebas!!!
        GameInfo.InventoryIsOpen = newstate;
        GameInfo.gameIsPaused = newstate;
        if(!newstate){
            PM.PlayersANIMATOR[0].speed = 1;
        }
        else{
            PM.PlayersANIMATOR[0].speed = 0;


        }
    
        
        
    }
    
    public void Equip(int id)
    {   
        var objeto=inventory.database.GetItem[id];
        PM.PlayersEQUIPMENT[0].Equipar(objeto);
        
    }
    
}
