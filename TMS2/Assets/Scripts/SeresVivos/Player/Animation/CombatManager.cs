using System;
using UnityEngine;
public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    public bool canReceiveInput;
    public bool inputReceived;

    public void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetMouseButton(0))
        {                inputReceived = true;

            if (canReceiveInput)
            {
                canReceiveInput = false;
            }
            
           
        }
    }

    public void InputManager()
    {
        canReceiveInput = !canReceiveInput;
    }
}

