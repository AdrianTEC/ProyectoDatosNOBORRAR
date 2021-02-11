using System.Collections.Generic;
using _Scripts.TaskSystem.Tasks;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    
    public TextMeshProUGUI tituloMesh;
    public TextMeshProUGUI DefinitionMesh;
    public List<GameTask> tasks;

    public GameTask currentTask;

    private void Start()
    {
        next();
    }

    public void next()
    {
        Debug.Log("siguienteTarea");
        if (tasks.Count <= 0) return;
        currentTask = tasks[0];
        tasks.RemoveAt(0);
        visualize();
    }

    public void addNew(GameTask task){
        tasks.Add(task);
        next();
    }

    private void visualize(){
        if(currentTask==null) return;
        tituloMesh.text = currentTask.taskName;
        DefinitionMesh.text = currentTask.definition;
    }
    
}
