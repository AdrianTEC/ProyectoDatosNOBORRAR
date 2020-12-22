using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMoving : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioS;

    public AudioClip sonido;
    void Start()
        {
            rb= gameObject.GetComponent<Rigidbody>();
            audioS= gameObject.GetComponent<AudioSource>();
            rb.velocity = new Vector3(0,0,0);
        }

    // Update is called once per frame
    void Update()
        {
            float velocidad= Mathf.Sqrt( Mathf.Pow(rb.velocity.x,2)+Mathf.Pow(rb.velocity.y,2) +Mathf.Pow(rb.velocity.z,2)   );
            Debug.Log(velocidad);
            if(velocidad>1&& !audioS.isPlaying)
                {
                    audioS.Play();
                }
            if(velocidad<1)
                {
                    audioS.Stop();
                }
        }
}
