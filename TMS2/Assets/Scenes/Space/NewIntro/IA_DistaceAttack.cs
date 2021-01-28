using UnityEngine;

public class IA_DistaceAttack : MonoBehaviour{

    public Transform pointer;
    public float rotationSpeed;
    public float shootTime = 1f;
    public float test=2;
    
    private Transform player;
    private float bulletSpeed;
    private bool canShoot = true;

    private void Start(){
        bulletSpeed = ObjectPooler.SharedInstance.GetPooledObject("EnemyBullet").GetComponent<Rigidbody>().velocity
            .magnitude;
        player = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("prepareShoot",.1f,shootTime);
    }



    public void prepareShoot(){
        transform.LookAt(player.position+player.forward*test);
        shoot();

    }

    private void shoot(){
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("EnemyBullet");
        if (bullet != null){
            var transform1 = pointer.transform;
            bullet.transform.position = transform1.position;
            bullet.transform.forward = transform1.forward;
            bullet.SetActive(true);
        }

        Invoke(nameof(canShootAgain), shootTime);
    }

    private void canShootAgain(){
        canShoot = true;
    }

}
