using UnityEngine;
using UnityEngine.AI;

public class Following : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject Target { set; get; }
    public float MaxAproach{ set; get; }
    public float WalkSpeed{ set; get; }
    public bool canFollow;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        if (!canFollow) return;
        Debug.Log("following");
        Vector3 targetPos = Target.transform.position;
        _agent.SetDestination(targetPos);
    
        if (Vector3.Distance(transform.position, targetPos) > MaxAproach) 
            _agent.speed =WalkSpeed ;

        else
            _agent.speed = 0;
    }
}
