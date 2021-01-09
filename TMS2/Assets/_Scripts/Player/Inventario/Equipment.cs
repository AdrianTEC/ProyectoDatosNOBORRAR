
using System;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private InventoryController ic;
    public GameObject WEAPON;
    [HideInInspector]
    public Weapon weaponClass;
    public int WEAPONID;
    public Transform  ManoDerecha;


    private void Start()
    {
        ic = GameObject.FindWithTag("PLAYER_MANAGER").GetComponent<InventoryController>();
        if (ManoDerecha.childCount == 1)
        {
            WEAPON = ManoDerecha.GetChild(0).gameObject;
            Posicionar();
        }
        
    }

    public void Posicionar()
    {
        WEAPON.transform.position = ManoDerecha.position;
        WEAPON.transform.parent = ManoDerecha.parent;
        WEAPON.transform.rotation=ManoDerecha.rotation;
        weaponClass = WEAPON.GetComponent<Weapon>();
    }
    public  void Equipar(ItemObject objeto)
    {
        if (objeto.Id == WEAPONID) return;
        var newWeapon = Instantiate(objeto.prefab);
        WEAPONID = objeto.Id;
        if (WEAPON == null)
            WEAPON = newWeapon;
        else
        {
            Destroy(WEAPON);
            WEAPON = newWeapon;
        }

        Posicionar();

    }
    
    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            ic.AddItem(_item,1);
            Destroy(other.gameObject);
        }
    }
    
}
