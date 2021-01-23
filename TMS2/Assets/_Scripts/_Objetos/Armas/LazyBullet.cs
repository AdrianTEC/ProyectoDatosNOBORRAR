
using UnityEngine;

public class LazyBullet : MonoBehaviour
{
    public float velocity;
    public GameObject explosion;
    public Rigidbody rb;
    public int damage { set; get; }
    public float pushConstant{ set; get; }

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
        DamageInteractuable dmi = other.GetComponent<DamageInteractuable>();
        if (dmi!=null)
        {
            dmi.recibeImpact(damage);
        }
        pushOther(other.gameObject);
        Destroy(gameObject);


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
