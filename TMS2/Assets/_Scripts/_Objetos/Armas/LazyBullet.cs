using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyBullet : MonoBehaviour
{
    public float velocity;
    public GameObject explosion;
    public Rigidbody rb;

    private void Start()
    {
        //rb.AddForce(Vector3.forward*velocity,ForceMode.Impulse);
        rb.velocity=transform.forward*velocity;

    }

    void Update()
    {
        //transform.Translate(Vector3.forward * (velocity * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) return;
        GameObject explosioninstance= Instantiate(explosion);
        explosioninstance.transform.position = transform.position;
        Destroy(gameObject);
    }
}
