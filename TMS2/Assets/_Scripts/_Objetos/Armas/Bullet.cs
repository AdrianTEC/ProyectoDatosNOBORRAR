using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Bullet : MonoBehaviour {

	public GameObject explo;
	public int time;
	private Transform myCamera;
	public int damage=1;
	public List<string> ignoreCollisions;
	private BoxCollider boxCollider;
	public float force=900;
	public Rigidbody rb;

	private Transform target;

	public string[] following;  
	// Use this for initialization
	void Start () {
		Invoke("dest",time);
		transform.forward = Camera.main.transform.forward;
		boxCollider = gameObject.GetComponent<BoxCollider>();

	}
	
	void dest()
	{
		Destroy(gameObject);
	}

	public void Propulse(Vector3 direction)
	{
		rb.AddForce((direction) * force,ForceMode.VelocityChange);

	}
	public void Propulse(RaycastHit target)
	{

		transform.LookAt(target.point);

		rb.AddForce((transform.forward) * force,ForceMode.VelocityChange);

	}
	
	private void Update()
	{
		if(target!=null)
			transform.LookAt(target);
	}

	void OnCollisionEnter(Collision col) {
	
		if(!ignoreCollisions.Contains(col.collider.tag))
		{
			GameObject exp = Instantiate(explo);
			exp.transform.position = transform.position;

			DamageInteractuable interactuable = col.gameObject.GetComponent<DamageInteractuable>();
			if (interactuable != null)
				interactuable.recibeImpact(damage);

			Destroy(gameObject);
		}
		else
		{
			Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(),boxCollider );
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("detectado: " +other.tag + "autodirgido: "+following.Contains(other.tag));
		if (following.Contains(other.tag))
		{
			target = other.transform;
		}
	}
}


