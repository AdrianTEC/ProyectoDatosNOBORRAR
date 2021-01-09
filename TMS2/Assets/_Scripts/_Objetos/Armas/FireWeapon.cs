

using UnityEngine;

public class FireWeapon :Weapon
{

    public GameObject bullet;

    public override void Attack()
    {
        Instantiate(bullet);
    }
}
