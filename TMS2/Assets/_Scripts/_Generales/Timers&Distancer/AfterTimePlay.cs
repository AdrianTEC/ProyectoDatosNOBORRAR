using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterTimePlay : MonoBehaviour{
    public AudioSource audioSource;
    public float seconds;
    void Start()
    {
        Invoke(nameof(play),seconds);
    }

    void play()
    {
        audioSource.Play();         
        Invoke(nameof(play),seconds);

    }
}
