using System;
using Cinemachine;
using UnityEngine;

namespace _Scripts._Generales.Camera{
    public class CameraShake : MonoBehaviour, ExtraBehavior
    {
        public CinemachineVirtualCamera cinemachineVirtualCamera;
        private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
        public float intensity;
        public float timer;
        private float shakeTimer;
        private float shakeTimerTotal;
        private float startIntensity;

        void Awake()
        {
          if(!cinemachineVirtualCamera){
              GameObject cameraObj = GameObject.FindGameObjectWithTag("Cinemachine");
              cinemachineVirtualCamera = cameraObj.GetComponent<CinemachineVirtualCamera>();
          }
          cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void OnDestroy(){
//            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        }

        private void shakeCamera()
        {
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
            shakeTimer = timer;
            shakeTimerTotal = timer;
            startIntensity = intensity;
        }

        private void Update(){
            if (!(shakeTimer > 0)) return;
            shakeTimer -= Time.deltaTime;
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));
        }

        public void act(){
            shakeCamera();
        }
    }
}