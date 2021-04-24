
using System;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class SpaceShipDead : Death
{

    public GameObject target;
    public GameObject explosion;
    private Animator transition;
    public AudioSource audioSource;
    private LevelLoader levelLoader;

    private void Start(){
        transition = GameObject.FindWithTag("MapTransition").GetComponent<Animator>();
        transition.Play("RoomTransition");
        levelLoader = transition.GetComponent<LevelLoader>();

    }

    public override void act()
    {
        Invoke("load",3);
        Instantiate(explosion).transform.position = target.transform.position;
        //Destroy(target);
        target.SetActive(false);

        audioSource.enabled = false;
        
    }

    private void OnDisable(){
        Invoke("load",3);
 
    }

    private void toGameOverScreen(){
        levelLoader.LoadLevelAsync("GameOver");
    }

    public void load()
    {
        transition.Play("Closed");
        float duration;
        duration = transition.GetCurrentAnimatorStateInfo(0).length;
        Invoke(nameof(toGameOverScreen),duration/2);

    }
    
    
 
    
    
}

