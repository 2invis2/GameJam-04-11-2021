using Assets.Scripts.FeatureStorages;
using MurphyInc.Core.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum BasicMovementType
{
    Stand,
    TurnAndMove,
    TurnThenMove
}
[RequireComponent(typeof(Rigidbody2D))]
public class MovementComponentOld : MonoBehaviour
{
    static readonly Vector3 globalForward = Vector3.forward;
    [SerializeField] BasicMovementType behavourType = BasicMovementType.TurnThenMove;
    [SerializeField] Rigidbody2D rigidbodySelf;
    [SerializeField] Transform subjectiveDir;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float turnSpeed = 1f;
    const float turnCoeff = 180f;
    const float distSmall = 0.01f; // this is actually square of that distance
    const float distEpsilon = 0.001f;
    const float angleEpsilon = 1f;
    [SerializeField] Transform target;
    public Transform Target { get => target; }
    public UnityAction OnTargetReached;
    private void Awake()
    {
        if (rigidbodySelf == null) rigidbodySelf = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        if (subjectiveDir == null) SetupSubjDirection();
    }
    private void Update()
    {

#if UNITY_EDITOR
        Debug.DrawRay(transform.position, subjectiveDir.up, Color.green);
        if (target != null) Debug.DrawLine(transform.position, target.position);
#endif
    }
    private void FixedUpdate()
    {
        switch (behavourType)
        {
            case BasicMovementType.TurnAndMove:
                if (target != null) TurnAndMoveDirectlyToPoint(target.position);
                else Stop();
                break;
            case BasicMovementType.TurnThenMove:
                if (target != null) TurnThenMoveToPoint(target.position);
                else Stop();
                break;
            default:
                Stop();
                break;
        }
    }

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
    public float TurnSpeed
    {
        get => turnSpeed;
        set => turnSpeed = value;
    }

    #region BasicMovement
    void TurnAndMoveDirectlyToPoint(Vector2 point)
    {
        Vector2 direction = point - (Vector2)transform.position;
        var distSqr = direction.sqrMagnitude;
        if (distSqr < distEpsilon)
        {
#if TELEPORT_IF_CLOSE
            transform.SetPositionAndRotation(point,transform.rotation);
#endif
            OnTargetReached();
            return;
        }//don't move to zero-vector direction
        if (distSqr < distSmall) TurnToDirInstantly(direction);
        else TurnToDir(direction);

        //if (IsDirectionForwardSubjective(direction)) 
        if (Vector2.Angle(subjectiveDir.up, direction) < Mathf.Min(Vector2.Angle(subjectiveDir.right, direction), Vector2.Angle(-subjectiveDir.right, direction)))
        {
            MoveDirectlyForward(direction);
        }
        else rigidbodySelf.velocity = Vector2.zero;
    }
    void TurnThenMoveToPoint(Vector2 point)
    {
        Vector2 direction = point - (Vector2)transform.position;
        var distSqr = direction.sqrMagnitude;
        if (distSqr < distEpsilon)
        {
#if TELEPORT_IF_CLOSE
            transform.SetPositionAndRotation(point, transform.rotation);
#endif
            OnTargetReached();
            return;
        }//don't move to zero-vector direction
        if (Vector2.Angle(subjectiveDir.up, direction) > angleEpsilon)
        {
            Stop();
            TurnToDir(direction);
        }
        else
        {
            MoveDirectlyForward(direction);
        }
    }
    float MoveDirectlyForward(Vector2 direction)
    {
        if (direction.sqrMagnitude < distEpsilon)
        { //too close
            OnTargetReached();
            return 0f;
        }

        var speed = Mathf.Min(direction.magnitude * moveSpeed * 5f, moveSpeed);// * Mathf.Cos(Vector2.Angle(subjectiveDir.up, direction));
        rigidbodySelf.velocity = speed * subjectiveDir.up;
        return speed;
    }
    void Stop()
    {
        rigidbodySelf.velocity = Vector3.zero;
    }
    float TurnToDir(Vector2 direction)
    {
        if (direction.sqrMagnitude < float.Epsilon) return 0f;//don't turn to zero-vector direction
        var curdir = subjectiveDir.up;
        float currAngleDelta = Vector2.SignedAngle(curdir, direction);
        float sign = Mathf.Sign(currAngleDelta);
        float angleChange = turnSpeed * sign * turnCoeff * Time.fixedDeltaTime;
        if ((sign > 0) ^ (angleChange < currAngleDelta)) angleChange = currAngleDelta;
        subjectiveDir.Rotate(globalForward, angleChange);
        return Vector2.SignedAngle(subjectiveDir.up, direction);
    }
    void TurnToDirInstantly(Vector2 direction)
    {
        if (direction.sqrMagnitude < float.Epsilon) return;//don't turn to zero-vector direction}
        if (Vector2.Angle(subjectiveDir.up, direction) < float.Epsilon) return;
        subjectiveDir.LookAt(subjectiveDir.position + Vector3.forward, direction);
    }
    #endregion
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    public void SetBasicMovementType(BasicMovementType newBehaviour)
    {
        behavourType = newBehaviour;
    }
    #region directionChecks
    bool IsDirectionLeftSubjective(Vector2 direction)
    {
        return Vector2.Dot(direction, subjectiveDir.right) < 0f;
    }
    bool IsDirectionRightSubjective(Vector2 direction)
    {
        return Vector2.Dot(direction, subjectiveDir.right) > 0f;
    }
    bool IsDirectionForwardSubjective(Vector2 direction)
    {
        return Vector2.Dot(direction, subjectiveDir.up) > 0f;
    }
    bool IsDirectionBackwardsSubjective(Vector2 direction)
    {
        return Vector2.Dot(direction, subjectiveDir.up) < 0f;
    }
    #endregion
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (subjectiveDir == null) SetupSubjDirection();
    }
#endif
    void SetupSubjDirection() {
        if (subjectiveDir != null) return;
        Transform subjObj = null;
        for (int i = 0; i < transform.childCount; i++) {
            var child = transform.GetChild(i);
            if (child.gameObject.name == "CurrentDirection") {
                subjObj = child;
                break;
            }
        }
        if (subjObj == null) subjObj = new GameObject("CurrentDirection").transform;
        subjObj.SetPositionAndRotation(transform.position, transform.rotation);
        subjObj.SetParent(transform);
        subjectiveDir = subjObj;
    }
}
