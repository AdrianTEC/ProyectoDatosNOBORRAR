using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class DummyEscapePod : MonoBehaviour{
    private bool ready;
    private bool parachuteOn;
    public float speed;
    
    private Animator anim;
    
    public float acelerationConstant;
    public float parachuteSpeed;
    public GameObject loader;
    private Vida life;
    
    
    private float hTototal;
    private float hRelativaTotal;//se encarga de la posicion de la imagen
    private float estelaSize;
    [Header("Collisions")]
    public float atmosDistance;
    public float activationDistance;
    public float atmosAceleration;
    public RectTransform image;
    [Header("Sounds")] 
    public AudioSource splash;
    public AudioSource atmosphereSound;
    void Start(){
        anim = GetComponent<Animator>();
        hTototal = transform.position.y;
        hRelativaTotal = image.position.y;
        life = GetComponent<Vida>();
        Application.targetFrameRate = 60;

    }

    void Update(){
        keys();
        freeFallState();
        updateCanvas();
        aceleration();
        
    }

    public void aceleration(){
        //estela.transform.localScale=new Vector3()
        if (parachuteOn){
            acelerationConstant = 0.01f;
        }
            speed += acelerationConstant;
   
        
    }

    public void updateCanvas(){
        float newPos = hRelativaTotal * (transform.position.y / hTototal);
        image.position = new Vector3(image.position.x, newPos);
    }
    public void freeFallState(){
        transform.Translate(new Vector3(0,-speed,0)*Time.deltaTime);

        if (transform.position.y < atmosDistance && !parachuteOn && transform.position.y > activationDistance){
           
            anim.SetBool("estela",true);
            acelerationConstant -= atmosAceleration;
        }
        
        if (transform.position.y < activationDistance){
            anim.SetBool("estela",false);
            ready = true;
        }
        
        if(transform.position.y<0 ){
            splash.Play();
            atmosphereSound.Stop();
            if(  !parachuteOn)
            {
                life.recibeImpact(100, attackTypes.cortante);
                
            }
            
            anim.SetInteger("parachute", 3);
            acelerationConstant = 0;
            speed = 0;
            Invoke("load",8);
            //       Destroy(this);
        }
    }

    public void load(){
        loader.SetActive(true);
    }
    public void keys(){
        if (Input.GetKeyDown(KeyCode.Space)){
            if (ready && !parachuteOn){
                parachuteOn = true;
                
                
                anim.SetInteger("parachute", 1);
            }
            else   
                anim.SetInteger("parachute",2);
            
        }
    }

    public void SlowDown(){
        speed = parachuteSpeed;
        atmosphereSound.Stop();
    }
}
