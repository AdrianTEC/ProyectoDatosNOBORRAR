using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnDistance : MonoBehaviour{
    public GameObject[] targets;
    public float distance;
    private Transform player;
    void Start(){
        player = GameObject.FindWithTag("Player").transform;
        foreach (GameObject target in targets){
            target.SetActive(false);
        }
    }

    void Update()
    {
        Debug.Log("dist: ");
        Debug.Log(Vector3.Distance(transform.position, player.position));
        
        if (Vector3.Distance(transform.position, player.position) < distance ){
            foreach (GameObject target in targets){
                if(target!=null)
                    target.SetActive(true);
            }
        }
        else{
            foreach (GameObject target in targets){
                if(target!=null)
                    target.SetActive(false);
            }

        }
    }
}
