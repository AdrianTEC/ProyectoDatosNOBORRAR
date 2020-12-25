using System;
using UnityEngine;

[Serializable]
public abstract class Task:MonoBehaviour
{
    public  bool enabled;
    public string name ="It is your task Name";
    public string definition= "That is what the mision is about";
    public Task[] steps;
    public Participants[] _participants;

    public void CompleteTask()
    {
        reward.Act();
    }
    public Reward reward;
    public abstract void Initialize();
    public abstract void Visualize();
}

public abstract class Participants 
{
    public Task task;
    public abstract void Interactuar();
}

public interface Reward 
{
    void Act();
}