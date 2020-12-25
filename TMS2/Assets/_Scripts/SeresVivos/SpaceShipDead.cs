using System.Collections;
using System.Collections.Generic;
using _Scripts.Player.VueloEspacial.Flight;
using UnityEngine;

public class SpaceShipDead : Death
{

    public GameObject target;
    public GameObject explosion;
    public PlayerFlightControl control;
    public CameraFlightFollow cameraControl;
    public CustomPointer pointer;
    public AudioSource audioSource;
    public override void act()
    {
        Instantiate(explosion).transform.position = target.transform.position;
        Destroy(target);
        control.enabled = false;
        pointer.enabled = false;
        cameraControl.enabled = false;
        audioSource.enabled = false;
        Invoke("load",3);
    }

    public void load()
    {
        LevelLoader.LoadLevel("GameOver");
    }
}

