using UnityEngine;

public class EnemyStalkState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entering Stalk State");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.transform.LookAt(enemy.player.position);
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider other)
    {

    }
}
