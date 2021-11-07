using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Assets.Scripts.FeatureStorages;
using UnityEditor.UIElements;
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
            if ((foundObjects.Count > 0) && (!FeatureStorageRooms.Instance.GetByName(("RestrictedAccess"+room.GetCurrentRoom())).IsEnable)) {
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

    public void Unchase()
    {
        movement.SetTarget(transform);
        isChasing = false;
    }
    
    
}
