using _Scripts;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Equipment equipment;
    public bool canDettectCols=true;

    private void OnTriggerEnter(Collider other){
        if(!canDettectCols) return;
        Invoke(nameof(dettectAgain),0.01f);
        canDettectCols = false;
        if(other.CompareTag("Player")) return;
        IDamageInteractuable dmi = other.GetComponent<IDamageInteractuable>();
        if (dmi!=null)
        {
            dmi.recibeImpact(equipment.weaponClass.damage);
        }
        pushOther(other.gameObject);

    }

    private void dettectAgain(){
        canDettectCols = true;
    }
    private void pushOther(GameObject other)
    {
        Rigidbody rigidbody;

        rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.AddForce(transform.forward*equipment.weaponClass.pushConstant);
        }

    }
}
