using UnityEngine;

public enum SpaceEnemyType
{
    torreta,
    nave,
}

public class enemySpaceAttack : MonoBehaviour
{
    private GameObject player;
    public int mindist;
    public SpaceEnemyType type;
    public Transform weapon_hardpoint_1;
    public GameObject bullet;
    public float velocity;
    private Rigidbody rb;

    
    private bool canIshoot=true;

    void Start()
    {
        if(type!= SpaceEnemyType.torreta)
            rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
        if(type== SpaceEnemyType.nave) 
            transform.LookAt(player.transform);
        
        if (Vector3.Distance(transform.position, player.transform.position)<mindist)
        {
            if (type == SpaceEnemyType.torreta)
                transform.LookAt(player.transform);
            fireShot();
        }
        else
                rb.velocity = transform.forward * velocity; //Apply speed
    }

    private void fireShot() {


        if(!canIshoot) return;

        canIshoot = false;
        GameObject shot1 = Instantiate(bullet, weapon_hardpoint_1.position, Quaternion.identity);
        shot1.GetComponent<Bullet>().Propulse(transform.forward);
        shot1.transform.rotation = weapon_hardpoint_1.rotation;
		Invoke("ShootAgain",0.5f);
        
	
    }

    private void ShootAgain()
    {
        canIshoot = true;
    }

 

    
}
