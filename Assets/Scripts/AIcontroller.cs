
using UnityEngine;
using UnityEngine.AI;

public class AIcontroller : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    private int currentPatrolPoint = 0;
    private Animator animator;
    bool animationPlayed = false;
    bool isHited = false;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNextPatrolPoint();
        animator = GetComponent<Animator>();
    }

    void SetNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.destination = patrolPoints[currentPatrolPoint].position;
        currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
    }
    // Update is called once per frame
    void Update()
    {
        animationPlayed = isHited || animator.GetCurrentAnimatorStateInfo(0).IsName("Falling Down") || animator.GetCurrentAnimatorStateInfo(0).IsName("Getting Up");

        if (animationPlayed)
        {
            
            if (isHited && animator.GetCurrentAnimatorStateInfo(0).IsName("Getting Up"))
            {
                isHited = false;
                animator.SetBool("isHited", isHited);
            }
        }
        else
        {
            if (agent.isStopped)
            {
                agent.isStopped = false;
            }
            if (!agent.pathPending && agent.remainingDistance < 0.1f)
            {
                SetNextPatrolPoint();
            }
            

            animator.SetFloat("moveAmount", agent.velocity.magnitude / agent.speed, 0.2f, Time.deltaTime);

        }
    }


    public void Collision()
    {
        if (!animationPlayed)
        {
            agent.isStopped = true;
            isHited = true;
            animator.SetBool("isHited", isHited);
        }
    }
}
