using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : EnemyBase
{
    bool isChasing = false;
    [SerializeField] float chaseSpeed;
    Transform chaseTarget;
    protected override void DetectionResult(List<GameObject> foundObjects)
    {
        base.DetectionResult(foundObjects);
        if (isChasing) {
            movement.SetTarget(chaseTarget);
        }
        else
        {
            if (foundObjects.Count > 0) {
                isChasing = true;
                //movement.SetBasicMovementType(BasicMovementType.TurnAndMove);
                if (chaseSpeed != default) movement.MoveSpeed = chaseSpeed;
                movement.Agent.acceleration = chaseSpeed * 3f;
                EnemyDirector.Instance.UnregisterEnemy(this);
                //movement.SetTarget(foundObjects[0].transform);
                chaseTarget = foundObjects[0].transform;
            }
        }
    }
}
