using System;
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
        inventoryDisplay.SetBool(Open,!inventoryDisplay.GetBool(Open));
    }
    
    public void Equip(int id)
    {   
        var objeto=inventory.database.GetItem[id];
        PM.PlayersEQUIPMENT[0].Equipar(objeto);
        
    }
    
}
