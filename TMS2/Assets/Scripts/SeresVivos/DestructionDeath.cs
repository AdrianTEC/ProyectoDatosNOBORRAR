
using System;
using UnityEngine;

public class DestructionDeath : Death
{
    public GameObject cadaver;

    public override void act()
    {
        if(!canDie) return;
        canDie = false;
        explotar();
    }
    private void explotar()
    {

        Instantiate(cadaver, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

  
}
