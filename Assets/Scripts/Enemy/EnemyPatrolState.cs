using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyBaseState
{
    public EnemyStateManager stateManager;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entering Patrol State");

        stateManager = GameObject.Find("Enemy").GetComponent<EnemyStateManager>();

        stateManager.navMeshAgent.SetDestination(stateManager.waypoints[0].position);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (stateManager.navMeshAgent.remainingDistance < stateManager.navMeshAgent.stoppingDistance)
        {
            
            stateManager.m_CurrentWaypointIndex = (stateManager.m_CurrentWaypointIndex + 1) % stateManager.waypoints.Length;
            stateManager.navMeshAgent.SetDestination(stateManager.waypoints[stateManager.m_CurrentWaypointIndex].position);
        }
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.SwitchState(enemy.StalkState);
        }
    }
}
