
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
        ((MeleeWeapon) equipment.weaponClass).DettectCollisions = true;
    }

    public void stopAttacks()
    {
        ((MeleeWeapon) equipment.weaponClass).DettectCollisions = false;

    }
}
