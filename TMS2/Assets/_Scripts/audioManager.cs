
using UnityEngine;

namespace _Scripts
{
    public class audioManager : MonoBehaviour
    {
        public AudioSource one;
        public AudioSource two;
        public AudioSource three;


        public void One()
        {
            one.Play();
        }
        public void Two()
        {
            two.Play();
        }
        public void Three()
        {
            three.Play();
        }


    }
}
