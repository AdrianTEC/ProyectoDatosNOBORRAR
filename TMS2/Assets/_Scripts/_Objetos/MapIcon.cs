using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIcon : MonoBehaviour{
    private void Start(){
        Transform transform1 = transform;
        Vector3 position = transform1.position;
        
        position = new Vector3(position.x,0 , position.z);
        
        transform1.position = position;
    }

    
}
