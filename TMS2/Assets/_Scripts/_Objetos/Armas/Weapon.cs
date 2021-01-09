using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected abstract void Attack(bool state);
    protected int damage;
   
}
