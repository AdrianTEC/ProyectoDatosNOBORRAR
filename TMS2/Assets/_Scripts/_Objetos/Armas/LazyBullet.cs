
using System;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class LazyBullet : MonoBehaviour
{
    public float velocity;
    public GameObject explosion;
    public Rigidbody rb;
    public int damage;
    public float pushConstant;
    public List<string> ignoretags;
    public bool destroyOnImpact = true;
    


private void OnEnable(){
     rb.velocity=transform.forward*velocity;
}

private void Start(){ 
    rb.velocity=transform.forward*velocity;
}


private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")|| ignoretags.Contains(other.tag)) return;
        
        GameObject explosioninstance= Instantiate(explosion);
        explosioninstance.transform.position = transform.position;
        IDamageInteractuable dmi = other.GetComponent<IDamageInteractuable>();
        dmi?.recibeImpact(damage);

        pushOther(other.gameObject);
        if (destroyOnImpact) Destroy(gameObject);
        else gameObject.SetActive(false);

            
    }
    private void pushOther(GameObject other)
    {
        Rigidbody rigidbody;

        rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.AddForce(-transform.forward*pushConstant);
        }

    }
}
