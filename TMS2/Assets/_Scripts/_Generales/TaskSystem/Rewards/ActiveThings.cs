using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.TaskSystem.Tasks;
using UnityEngine;

public class ActiveThings : IReward
{
    public GameObject[] targets;

    private void Start()
    {
        foreach (var obj in targets)
        {
            obj.SetActive(false);
        }
    }

    public override void Act()
    {
        foreach (var obj in targets)
        {
            obj.SetActive(true);
        }
    }
}
