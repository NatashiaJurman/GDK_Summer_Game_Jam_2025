using UnityEngine;

public class EnemyStalkState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entering Stalk State");
        enemy.GetComponent<FieldOfView>().BeginChecking();

        enemy.navMeshAgent.isStopped = true;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.transform.LookAt(enemy.player.position);

        if (enemy.navMeshAgent.isStopped)
        {
            enemy.SwitchState(enemy.ChaseState);
        }
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider other)
    {

    }
}
