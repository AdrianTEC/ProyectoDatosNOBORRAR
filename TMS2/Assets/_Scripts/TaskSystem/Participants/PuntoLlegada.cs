
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
        if(other.CompareTag("Player"))
            Interactuar();
    }
}
