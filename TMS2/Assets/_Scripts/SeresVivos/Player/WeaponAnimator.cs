
using _Scripts._Objetos.Armas;
using UnityEngine;

public class WeaponAnimator : MonoBehaviour
{
    private Equipment equipment;
    void Start()
    {
        equipment = transform.parent.GetComponent<Equipment>();
    }

    public void generateSlash()
    {
        
        equipment.weaponClass.Attack();

    }

    public void enableAttacks()
    {
        if(equipment.weaponClass is MeleeWeapon)
            ((MeleeWeapon) equipment.weaponClass).DettectCollisions = true;
        else{
            equipment.weaponClass.Attack();
        }
    }

    public void stopAttacks()
    {
        ((MeleeWeapon) equipment.weaponClass).DettectCollisions = false;

    }
}
