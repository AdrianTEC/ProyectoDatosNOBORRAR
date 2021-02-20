using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner_Door : MonoBehaviour{
    
    public Transform door;
    public Transform spawnPoint;
    public Transform exitPoint;
    public List<GameObject> prefabs;
    public int maxInstances;

    public  Vector3 doorOffset;
    private Vector3 velocity= Vector3.zero;

    public float doorMovingTime;
    public float doorOpenTime;
    private float distanceTolerance=0.0000001f;
    private bool opening;
    private bool keepAsking = true;

    

    public void moveDoor(Vector3 target){

        door.localPosition = Vector3.SmoothDamp(door.localPosition, target, ref velocity, doorMovingTime);
    }
  
    public void swithDoorMovement(){
        opening = !opening;
    }

    public void close(){
 
        Debug.Log("close");
        keepAsking = true;
        opening = false;
    }

    public void open(){
        Debug.Log("open");
        NavMeshHit closestHit;
        
        if( NavMesh.SamplePosition(  spawnPoint.position, out closestHit, 5000, 1 ) ){
            GameObject instance= Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
            instance.transform.position = spawnPoint.position;
            NavMeshAgent instanceNav= instance.GetComponent<NavMeshAgent>();
            maxInstances--;
            instanceNav.enabled = true;
            instanceNav.SetDestination(exitPoint.position);

        }

             
        keepAsking = true;
        opening = true;
    }
    

    void Update(){
      
        if (opening){
            
            if(Vector3.Distance(door.localPosition,doorOffset)<=distanceTolerance){
                if (!keepAsking) return;
                keepAsking = false;
                Invoke(nameof(close), doorOpenTime);
            }
            else moveDoor(doorOffset);
        }
        else{
           
           if(Vector3.Distance(door.localPosition,Vector3.zero)<=distanceTolerance){
               if (!keepAsking) return;
               keepAsking = false;
               if(maxInstances<=0)
                   Destroy(this);
               Invoke(nameof(open), doorOpenTime);
           }
           else moveDoor(Vector3.zero);
        }

    }
}
