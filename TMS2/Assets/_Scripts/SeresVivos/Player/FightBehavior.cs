using UnityEngine;

public class FightBehavior : MonoBehaviour
{
    public Animator _anim;
    private Equipment _equipment;
    private static readonly int Attack = Animator.StringToHash("Attack");


    void Start()
    {
        _equipment = GetComponent<Equipment>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)&& _anim.GetInteger(Attack)==0)
        {
            _anim.SetInteger(Attack,1);
            _anim.Play(Attack);
        }
    }
}
