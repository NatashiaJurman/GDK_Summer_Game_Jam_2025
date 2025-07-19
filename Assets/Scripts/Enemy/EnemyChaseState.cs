using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entering Chase State");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider other)
    {

    }
}
