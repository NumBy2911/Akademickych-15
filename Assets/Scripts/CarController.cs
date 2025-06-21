using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    [SerializeField]
    private int currentPatrolPoint = 0;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNextPatrolPoint();
    }

    private void Update()
    {
        if(agent != null)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.1f)
            {
                SetNextPatrolPoint();
            }
        }
    }

    void SetNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.destination = patrolPoints[currentPatrolPoint].position;
        currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
    }
}
