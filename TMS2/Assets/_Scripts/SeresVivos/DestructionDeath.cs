
using System;
using UnityEngine;

public class DestructionDeath : Death
{
    public GameObject cadaver;

    public override void act()
    {
        explotar();
    }
    private void explotar()
    {
        Instantiate(cadaver, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

  
}
