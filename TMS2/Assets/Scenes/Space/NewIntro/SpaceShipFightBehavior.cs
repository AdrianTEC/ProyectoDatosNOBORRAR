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
    private audioManager audioM;
    void Start()
    {
        audioM = GetComponent<audioManager>();
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
        audioM.PlaySoundFor(SoundType.attack);
        
        
        GameObject bulletInstance=Instantiate(bullet);
        bulletInstance.transform.position = pointer.position;
        bulletInstance.transform.forward = pointer.forward;
        
        LazyBullet bulletInfo = bulletInstance.GetComponent<LazyBullet>();
        bulletInfo.damage = damage;
        bulletInfo.pushConstant = pushConstant;
        
        Invoke( "canfireagain",shotTime);    

    }

    public void canfireagain()
    {
        canFire = true;
    }
}
