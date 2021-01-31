using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player"))
            Destroy(gameObject);
    }
}
