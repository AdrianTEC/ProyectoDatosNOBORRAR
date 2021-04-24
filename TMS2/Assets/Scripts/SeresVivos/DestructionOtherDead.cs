using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionOtherDead: Death
{
    public GameObject cadaver;
    public GameObject target;
    public override void act()
    {
        if(!canDie) return;
        canDie = false;
        explotar();
    }
    private void explotar()
    {
        Instantiate(cadaver, transform.position, Quaternion.identity);
        Destroy(target);
    }

  
}