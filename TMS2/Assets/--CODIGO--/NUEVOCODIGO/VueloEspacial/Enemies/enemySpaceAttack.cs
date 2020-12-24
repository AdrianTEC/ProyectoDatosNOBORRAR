using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SpaceEnemyType
{
    torreta,
    nave,
    nodriza
}

public class enemySpaceAttack : MonoBehaviour,BulletInteractuable
{
    private GameObject player;
    public int mindist;
    public SpaceEnemyType type;
    public Transform weapon_hardpoint_1;
    public GameObject bullet;
    private float velocity;
    private Rigidbody rb;

    public int life=1;
    public GameObject explosion;
    public Image senal;
    
    private bool canIshoot=true;

    void Start()
    {
        if(type== SpaceEnemyType.nodriza) return;
        if(type!= SpaceEnemyType.torreta)
            rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        velocity = 80;
        
    }

    void Update()
    {
        if(type== SpaceEnemyType.nodriza) return;
        
        if(type== SpaceEnemyType.nave) 
            transform.LookAt(player.transform);
        
        if (Vector3.Distance(transform.position, player.transform.position)<mindist)
        {
            if (type == SpaceEnemyType.torreta)
                transform.LookAt(player.transform);

            fireShot();
        }
        else
            if(type!= SpaceEnemyType.torreta)
                rb.velocity = transform.forward * velocity; //Apply speed
    }

    private void fireShot() {

        if(type== SpaceEnemyType.nodriza) return;

        if(!canIshoot) return;

        canIshoot = false;
        GameObject shot1 = Instantiate(bullet, weapon_hardpoint_1.position, Quaternion.identity);
        shot1.transform.rotation = weapon_hardpoint_1.rotation;
        shot1.GetComponent<Rigidbody>().AddForce((shot1.transform.forward) * 900f,ForceMode.VelocityChange);
		Invoke("ShootAgain",1);
        
	
    }

    private void ShootAgain()
    {
        canIshoot = true;
    }

    public void recibeImpact()
    {
        life--;
        if(life<=0)
            explotar();
    }

    private void explotar()
    {
        Destroy(senal.gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
