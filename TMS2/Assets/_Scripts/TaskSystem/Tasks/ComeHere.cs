
using _Scripts.TaskSystem.Tasks;
using UnityEngine;

public class ComeHere : GameTask
{
    public override void TellSomething()
    {
        participantsLen--;
        if (participantsLen <= 0)
            CompleteTask();
    }

    public override void Initialize()
    {
        
    }

  
}
