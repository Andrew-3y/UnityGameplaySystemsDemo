using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class CatWander:MonoBehaviour
{
    public float wanderRadius=5f;
    public float idleTime=2f;
    public float walkSpeed = 1.5f;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float timer;
    [SerializeField] private Animator animator;
    [SerializeField] public float runSpeed = 4.0f;
    [SerializeField] private bool isRunning;
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        PickNewDestination();
    }
    void Update()
    {
        timer+=Time.deltaTime;
        float speed = agent.velocity.magnitude;
        if (animator != null)
        {
        animator.SetFloat("Vert", speed);
        if (isRunning)
        {
            animator.SetFloat("State", speed);
        }
        else
        {
            animator.SetFloat("State", 0f);
        }
        }
        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            if (timer >= idleTime)
            {
                PickNewDestination();
                timer=0f;
            }
        }
    }
    void PickNewDestination()
    {
        float chance = Random.value;
        if (chance < 0.3f)
        {
        isRunning = true;
        }
        else
        {
        isRunning = false;
        }
        if (isRunning)
        {
        agent.speed = runSpeed;
        }
        else
        {
        agent.speed = walkSpeed;
        }
        Vector3 randomDirection=Random.insideUnitSphere*wanderRadius;
        randomDirection+=transform.position;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
