using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool menuActive;
    private GameObject panel;

    private void Start()
    {
        panel = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuActive = !menuActive;
            if (menuActive)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
                
            panel.SetActive(menuActive);
        }
        
    }
}
