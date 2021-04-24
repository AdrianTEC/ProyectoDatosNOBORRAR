using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerradura : MonoBehaviour, Interacuable{
    public InventoryController manager;
    private void Start(){
        manager = GameObject.FindGameObjectWithTag("PLAYER_MANAGER").GetComponent<InventoryController>();
    }

    public void interactuar(){
        if(manager.inventory.Container.contains(3))
            manager.inventory.RemoveItem(3);

    }
}
