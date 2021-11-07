using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyBase))]
[RequireComponent(typeof(MovementComponent))]
public class ChaserComponent : MonoBehaviour
{
    bool isChasing = false;
    [SerializeField] float chaseSpeed;
    Transform chaseTarget;
    public System.Predicate<Transform> isTargetLegal = (tr) => true;

    public bool IsChasing { get => isChasing; set => isChasing = value; }

    //protected override void DetectionResult(List<GameObject> foundObjects)
    //{
    //    base.DetectionResult(foundObjects);
    //    if (IsChasing) {
    //        movement.SetTarget(chaseTarget);
    //    }
    //    else
    //    {
    //        if (foundObjects.Count > 0) {
    //            IsChasing = true;
    //            //movement.SetBasicMovementType(BasicMovementType.TurnAndMove);
    //            if (chaseSpeed != default) movement.MoveSpeed = chaseSpeed;
    //            movement.Agent.acceleration = chaseSpeed * 3f;
    //            EnemyDirector.Instance.UnregisterEnemy(this);
    //            //movement.SetTarget(foundObjects[0].transform);
    //            chaseTarget = foundObjects[0].transform;
    //        }
    //    }
    //}
}
