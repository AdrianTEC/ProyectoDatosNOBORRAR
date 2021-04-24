using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float pushConstant;
    public abstract void Attack();

    public int damage;
   
}
