using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public int time;

    void Start()
    {
        Invoke("dest",time);

    }

    void dest()
    {
        Destroy(gameObject);
    }


}
