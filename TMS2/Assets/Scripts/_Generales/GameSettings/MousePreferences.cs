using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePreferences : MonoBehaviour{
    public Texture2D texture;
    void Start(){
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(texture,Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
