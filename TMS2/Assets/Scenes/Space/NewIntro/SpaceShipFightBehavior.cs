using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class SpaceShipFightBehavior : MonoBehaviour
{
    [Header("Object Reference")]
    public GameObject bullet;
    public float shotTime;
    public Transform pointer;
    [Header("Bullet Info")]
    public int damage=1;
    public int pushConstant=1;
    private bool canFire = true;
    
    private AudioSource audioM;
    private ParticleSystem shootParticles;
    void Start()
    {
        audioM = pointer.GetComponent<AudioSource>();
        shootParticles = pointer.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            Shoot();
    }

    private void Shoot()
    {
        if(!canFire) return;
        canFire = false;
        audioM.PlayOneShot(audioM.clip);
        
        /*
        GameObject bulletInstance=Instantiate(bullet);
        bulletInstance.transform.position = pointer.position;
        bulletInstance.transform.forward = pointer.forward;
        
        LazyBullet bulletInfo = bulletInstance.GetComponent<LazyBullet>();
        bulletInfo.damage = damage;
        bulletInfo.pushConstant = pushConstant;
        */
        
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("PlayerBullet"); 
        if (bullet != null) {
            var transform1 = pointer.transform;
            bullet.transform.position = transform1.position;
            bullet.transform.forward  = transform1.forward;
            bullet.SetActive(true);
            shootParticles.Play();
        }
        
        Invoke( "canfireagain",shotTime);    

    }

    public void canfireagain()
    {
        canFire = true;
    }
}
