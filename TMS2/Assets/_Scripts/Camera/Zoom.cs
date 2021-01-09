using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private CinemachineVirtualCamera Mycamera;
    public float velocity;
   void Start()
   {
       Mycamera = GetComponent<CinemachineVirtualCamera>();
   }

    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
            Mycamera.m_Lens.OrthographicSize -= velocity;

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
            Mycamera.m_Lens.OrthographicSize += velocity;

    }
}
