
using System;
using Unity.Mathematics;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private InventoryController ic;
    public GameObject WEAPON;
    [HideInInspector]
    public Weapon weaponClass;
    public int WEAPONID;
    public Transform  ManoDerecha;
    private Animator animator;

    private void Start(){
        animator =transform.GetChild(0).GetComponent<Animator>();
        ic = GameObject.FindWithTag("PLAYER_MANAGER").GetComponent<InventoryController>();
        if (ManoDerecha.childCount >= 1)
        {
            WEAPON = ManoDerecha.GetChild(0).gameObject;
            Posicionar();
        }
        
    }

    public void Posicionar()
    {
        WEAPON.transform.parent = ManoDerecha;
        WEAPON.transform.localPosition = Vector3.zero;

        WEAPON.transform.localRotation= quaternion.Euler(0,0,0);
        weaponClass = WEAPON.GetComponent<Weapon>();
        if (weaponClass is FireWeapon){
            Debug.Log("fireW");
            animator.SetLayerWeight(2,1);
        }
        else{
            animator.SetLayerWeight(2,0);

        }
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
