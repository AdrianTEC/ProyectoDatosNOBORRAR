

using UnityEngine;

public class FireWeapon :Weapon
{

    public GameObject bullet;

    protected override void Attack(bool state)
    {
        Instantiate(bullet);
    }
}
