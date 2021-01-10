using UnityEngine;


public abstract class Player : MonoBehaviour
{
    protected CharacterController controller;
    protected Animator _animator;
    protected string MOVING = "caminando";
    protected string ATACK  = "ataque";
    protected string INJURED = "injured";
    private Transform body;

    private void Awake()
    {
        body = transform.GetChild(0);
        controller = GetComponent<CharacterController>();
        _animator  = body.GetComponent<Animator>();
    }


    protected void Interactuar()
    {
        RaycastHit hit;
        var dist = 4;
        var inicio = body.position+ new Vector3(0,1,0);
        var final =  body.forward * dist;
        
        Debug.DrawRay(inicio,final);

        if (Physics.Raycast(inicio,final, out hit, 1))
        {
            Debug.Log(hit.collider.name);
            hit.collider.SendMessage("interactuar");
        }
    
        
    }
    
}

