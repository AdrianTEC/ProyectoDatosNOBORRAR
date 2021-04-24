using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantianteWhenDie : MonoBehaviour{

    public GameObject myPrefab;

    void OnDestroy()
    {
        Instantiate(myPrefab).transform.position = transform.position;
        Destroy(gameObject);
    }
}
