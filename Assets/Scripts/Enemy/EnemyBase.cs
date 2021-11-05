#define TELEPORT_IF_CLOSE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnemyBase : MonoBehaviour
{
    [SerializeField] DetectorComponent detector;
    [SerializeField] MovementComponent movement;

    public Transform MovementTarget => movement ? movement.Target : null;
    public UnityAction<EnemyBase> OnMovementTargetReached;

    protected virtual void Start()
    {
        Init();
    }
    protected virtual void Init()
    {
        if (detector == null) detector = GetComponent<DetectorComponent>();
        if (detector != null) { SetDetection("Player", DetectionResult); }
        if (movement == null) movement = GetComponent<MovementComponent>();
        if (movement != null) { movement.OnTargetReached = MovementCompleteResult; }
    }
    #region Movement
    protected virtual void MovementCompleteResult() {
        OnMovementTargetReached(this);
    }
    public void SetTarget(Transform target)
    {
        PrepareMovement();
        movement.SetTarget(target);
    }

    void PrepareMovement()
    {
        if (movement == null)
        {
            movement = gameObject.GetComponent<MovementComponent>();
            if (movement == null) movement = gameObject.AddComponent<MovementComponent>();
        }
    }
    #endregion
    #region Detection
    public void SetDetection(string tag, UnityAction<List<GameObject>> action) {
        PrepareDetector();
        detector.SetTagToDetect(tag);
        detector.OnDetection = action;
    }
    protected virtual void DetectionResult(List<GameObject> foundObjects) {
        //hardcoded right now
#if UNITY_EDITOR
        for (int i = 0; i < foundObjects.Count; i++) Debug.DrawLine(transform.position, foundObjects[i].transform.position,Color.red);
#endif
    }
    void PrepareDetector()
    {
        if (detector == null)
        {
            detector = gameObject.GetComponent<DetectorComponent>();
            if (detector == null) detector = gameObject.AddComponent<DetectorComponent>();
        }
    }
    #endregion
}