

using System;
using UnityEngine;

public class FireWeapon :Weapon
{

    public GameObject bullet;
    public Transform pointer;
    public float shotTime;
    private bool canFire= true;
    private AudioSource _audioSource;
    private void Start()
    {

        _audioSource = GetComponent<AudioSource>();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Attack()
    {
        if(!canFire) return;
        canFire = false;
        _audioSource.Play();
        Invoke( "canfireagain",shotTime);    
        GameObject bulletInstance=Instantiate(bullet);
        bulletInstance.transform.position = pointer.position;
        bulletInstance.transform.forward = pointer.forward;
    }

    public void canfireagain()
    {
        canFire = true;
    }
}
