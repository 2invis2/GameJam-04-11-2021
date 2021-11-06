using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : EnemyBase
{
    bool isChasing = false;
    [SerializeField] float chaseSpeed;
    protected override void DetectionResult(List<GameObject> foundObjects)
    {
        base.DetectionResult(foundObjects);
        if (isChasing) { 

        }
        else
        {
            if (foundObjects.Count > 0) {
                isChasing = true;
                movement.SetBasicMovementType(BasicMovementType.TurnAndMove);
                if (chaseSpeed != default) movement.MoveSpeed = chaseSpeed;
                EnemyDirector.Instance.UnregisterEnemy(this);
                movement.SetTarget(foundObjects[0].transform);
            }
        }
    }
}
