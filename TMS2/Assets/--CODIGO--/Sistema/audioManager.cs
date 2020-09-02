using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource caminar;
    public AudioSource pickUpItem;
    
    public AudioSource pain;


    public void Caminar()
        {
                caminar.Play();
        }
    public void PickUp()
        {
            pickUpItem.Play();
        }
    public void Gritar()
        {
                pain.Play();
        }


}
