using UnityEngine;

public enum amunitionType
{
	mesh,
	sprite
}
public class Bullet : MonoBehaviour {

	public GameObject explo;
	public int time;
	public amunitionType type;
	private Transform camera;

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
	
		Instantiate(explo, col.contacts[0].point, Quaternion.identity);

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