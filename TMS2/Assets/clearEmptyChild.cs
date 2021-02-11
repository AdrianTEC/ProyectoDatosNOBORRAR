using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearEmptyChild : MonoBehaviour
{
    void Start()
    {
        foreach (Transform transf in transform){
            if(transf.childCount==0)
                Destroy(transf.gameObject);
        }
    }

}
