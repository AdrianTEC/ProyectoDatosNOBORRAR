using _Scripts.TaskSystem.Tasks;
using UnityEngine;


public class DestroySomething :  IReward
{
    public GameObject[] targets;

    public override void Act()
    {
        foreach (GameObject ob in targets)
        {
            Destroy(ob);

        }
    }
}
