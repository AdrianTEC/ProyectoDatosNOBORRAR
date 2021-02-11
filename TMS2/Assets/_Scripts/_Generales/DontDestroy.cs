
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    
     void Awake()
      {
          DontDestroyOnLoad(gameObject);
          if (SceneManager.GetActiveScene().name== "GameOver"){
              Destroy(gameObject);
          }
          
          
      }
}   
