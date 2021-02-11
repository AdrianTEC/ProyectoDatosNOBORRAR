using UnityEngine;

namespace _Scripts.SeresVivos.Player.VueloEspacial{
    public class SpaceShipFightBehavior : MonoBehaviour
    {
        [Header("Object Reference")]
        public float shotTime;
        public Transform pointer;
        [Header("Bullet Info")]
        public int damage=1;
        public int pushConstant=1;
        private bool canFire = true;
        public bool bulletPool=true;
        public GameObject noPoolBullet;
        
        public GameObject specialBullet;
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
            if(Input.GetKeyDown(KeyCode.Mouse1))
                specialShoot();
        }

        private void specialShoot(){
            
           GameObject bulletInstance=Instantiate(specialBullet);
           bulletInstance.transform.position = pointer.position;
           bulletInstance.transform.forward = pointer.forward;
        }
        private void Shoot()
        {
            if(!canFire) return;
            canFire = false;
            audioM.PlayOneShot(audioM.clip);

            GameObject bullet;
            if (bulletPool){
                bullet= ObjectPooler.SharedInstance.GetPooledObject("PlayerBullet"); 
       
            }
            else{
                bullet = Instantiate(noPoolBullet);
            }
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
}
