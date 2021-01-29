
using System;
using UnityEngine;

public class LazyBullet : MonoBehaviour
{
    public float velocity;
    public GameObject explosion;
    public Rigidbody rb;
    public int damage;
    public float pushConstant;



private void OnEnable(){
     rb.velocity=transform.forward*velocity;

}

private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) return;
        GameObject explosioninstance= Instantiate(explosion);
        explosioninstance.transform.position = transform.position;
        DamageInteractuable dmi = other.GetComponent<DamageInteractuable>();
        if (dmi!=null)
        {
            dmi.recibeImpact(damage);
        }
        pushOther(other.gameObject);
        //Destroy(gameObject);
        gameObject.SetActive(false);
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
