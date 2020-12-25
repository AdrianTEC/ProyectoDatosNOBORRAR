using UnityEngine;

public enum amunitionType
{
	mesh,
	sprite
}
public class Bullet : MonoBehaviour {

	public GameObject explo;
	public int time;
	private Transform myCamera;

	// Use this for initialization
	void Start () {
		Invoke("dest",time);
		transform.forward = Camera.main.transform.forward;

	}
	void dest()
	{
		Destroy(gameObject);
	}



	void OnCollisionEnter(Collision col) {
	
		GameObject exp= Instantiate(explo);
		exp.transform.position = transform.position;
			
		BulletInteractuable interactuable = col.gameObject.GetComponent<BulletInteractuable>();
		if (interactuable !=null)
			interactuable.recibeImpact();
		
		Destroy(gameObject);
	}
	
}



public interface BulletInteractuable
{
	void recibeImpact();
}