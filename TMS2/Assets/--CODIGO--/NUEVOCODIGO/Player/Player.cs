using UnityEngine;

public class Player : MonoBehaviour
{
    protected CharacterController controller;
    protected Animator _animator;
    protected string MOVING = "caminando";
    protected string ATACK  = "ataque";
    protected string INJURED = "injured";

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        _animator  = transform.GetChild(0).GetComponent<Animator>();
    }
}
