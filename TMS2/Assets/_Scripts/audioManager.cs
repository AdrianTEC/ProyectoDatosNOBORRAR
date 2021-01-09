
using System;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
    item,
    explosion,
    damage,
    dead,
    walking,
    jump,
    attack
}
[Serializable]
public struct Sonido
{
    public SoundType Usage;
    public AudioSource Myaudio;
}

namespace _Scripts
{
    public class audioManager : MonoBehaviour
    {
        public List<Sonido> Sonidos;
        public Dictionary<SoundType, AudioSource> dictionary;

        private void Awake()
        {
            dictionary=new Dictionary<SoundType, AudioSource>();
            foreach (var sound in Sonidos)
            {
                dictionary.Add(sound.Usage,sound.Myaudio);
            }
            
        }

        public void PlaySoundFor(SoundType soundType)
        {
            dictionary[soundType].Play();
        }
     

    }
}
