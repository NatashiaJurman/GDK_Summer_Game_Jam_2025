using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    public EnemyPatrolState PatrolState = new EnemyPatrolState();
    public EnemyStalkState StalkState = new EnemyStalkState();
    public EnemyChaseState ChaseState = new EnemyChaseState();

    [Header("Patrol State Variables")]
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public int m_CurrentWaypointIndex;

    [Header("Stalk State Variables")]
    public Transform player;
    public Transform[] hidingSpot;

    void Start()
    {
        currentState = PatrolState;

        currentState.EnterState(this);
    }

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }



}
