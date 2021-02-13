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
        var inicio = body.position;
        var final =  body.forward * dist;
        
        Debug.DrawRay(inicio,final);

        if (Physics.Raycast(inicio,final, out hit, 1)){
            if(hit.transform.gameObject.CompareTag("interactuable"))
                hit.collider.SendMessage("interactuar");
        }
    
        
    }
    
}

