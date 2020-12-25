
using System;
using UnityEngine;

public abstract class Givers : MonoBehaviour
{
    /// <summary>
    /// THIS CLASS IS IN CHARGE TO GIVE ITEMS TO PLAYER
    /// </summary>
    protected abstract void GiveObject();
    protected abstract void Open();
    protected Animator anim;
    protected Player_Manager PM;
    private void Start()
    {
        anim = GetComponent<Animator>();
        if(PM==null)
            PM=GameObject.FindWithTag("PLAYER_MANAGER").GetComponent<Player_Manager>();
    }

    public void notify(){}
    
}
