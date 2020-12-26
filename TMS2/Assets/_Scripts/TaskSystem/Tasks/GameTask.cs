using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.TaskSystem.Tasks
{
    public abstract class GameTask:MonoBehaviour
    {
        public string taskName ="It is your task Name";
        public string definition= "That is what the mision is about";
        public int participants;
        protected int participantsLen;
        public IReward reward;

        public TaskManager taskManager;




        private void Start()
        {
            participantsLen = participants;
            taskManager = GameObject.FindWithTag("TaskManager").GetComponent<TaskManager>();
        }

        public void CompleteTask()
        {
            taskManager.Next();
            reward.Act();
        }

        public abstract void TellSomething();
        public abstract void Initialize();
    }
    
    public abstract class Participants:MonoBehaviour
    {
        public GameTask task;
        public abstract void Avisar();
        public abstract void Interactuar();
    }
    [Serializable]
    public abstract class IReward : MonoBehaviour
    {
        public abstract void Act();
    }
}
