
using System;
using _Scripts.TaskSystem.Tasks;
using UnityEngine;

public class PuntoLlegada  : Participants
{
   
    public override void Avisar()
    {
        task.TellSomething();
    }

    public override void Interactuar()
    {
        Avisar();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colision");
        if(other.CompareTag("Player"))
            Interactuar();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("colision");
        if (other.gameObject.CompareTag("Player"))
            Interactuar();
    }
}
