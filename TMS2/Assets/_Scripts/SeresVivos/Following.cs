using UnityEngine;
using UnityEngine.AI;

public class Following : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject Target { set; get; }
    public float MaxAproach{ set; get; }
    public bool canFollow;
    private Animator _animator;
    private static readonly int Walking = Animator.StringToHash("Walking");


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public void WalkTo(float speed)
    {
        _agent.speed =speed ;
        if (speed<=0)
        {
            _animator.SetBool(Walking,false);
            return;
        }
        
        
        Vector3 targetPos = Target.transform.position;
        _agent.SetDestination(targetPos);
        _animator.SetBool(Walking,true);


    }

}
