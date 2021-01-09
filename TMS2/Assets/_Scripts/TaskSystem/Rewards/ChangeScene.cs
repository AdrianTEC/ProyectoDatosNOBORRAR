using System.Collections;
using System.Collections.Generic;
using _Scripts.TaskSystem.Tasks;
using UnityEngine;

public class ChangeScene : IReward
{
    public string sceneTarget;
    
    public override void Act()
    {
        LevelLoader.LoadLevel(sceneTarget);
    }
}
