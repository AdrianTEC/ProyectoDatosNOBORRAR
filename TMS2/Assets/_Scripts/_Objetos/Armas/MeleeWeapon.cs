using UnityEngine;

public class MeleeWeapon : Weapon
{
    public GameObject slash;
    protected override void Attack(bool state)
    {
        slash.SetActive(state);
    }
    
    


}
