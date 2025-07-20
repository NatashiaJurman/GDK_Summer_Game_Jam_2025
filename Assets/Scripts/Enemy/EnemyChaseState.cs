using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entering Chase State");

        enemy.navMeshAgent.isStopped = false;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.navMeshAgent.SetDestination(enemy.player.transform.position);
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider other)
    {

    }
}
