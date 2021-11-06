#define TELEPORT_IF_CLOSE
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.FeatureStorages;
using MurphyInc.Core.Model;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected DetectorComponent detector;
    [SerializeField] protected MovementComponent movement;

    protected FeatureStorage featureStorage = FeatureStorageEnemy.Instance;
    protected FeatureStorage featureStorageRooms = FeatureStorageRooms.Instance;

    public Transform MovementTarget => movement ? movement.Target : null;
    public UnityAction<EnemyBase> OnMovementTargetReached = delegate { };

    protected virtual void Start()
    {
        Init();
        AddActionFeatures();
        //ActionFeatureInit();
    }

    private void ActionFeatureInit()
    {
        FeatureStorageEnemy.RandVelocity.Action += OnEnableRandVelocity;
    }

    private void OnEnableRandVelocity(string[] actionParams)
    {
        var rnd = Random.Range(0, 8);
        movement.MoveSpeed = movement.MoveSpeed * 0.4f + rnd * 0.6f;
    }

    protected virtual void Init()
    {
        GetParts();
        if (detector != null) { SetDetection("Player", DetectionResult); }
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
#if UNITY_EDITOR
    protected virtual void OnValidate() {
        GetParts();
    }
#endif
    protected virtual void GetParts()
    {
        if (movement == null) movement = GetComponent<MovementComponent>();
        if (detector == null) detector = GetComponent<DetectorComponent>();
    }

    private void AddActionFeatures()
    {
        foreach (var item in Rooms.Rooms.roomsDictionary)
        {
            var newActionFeature = new ActionFeature("RestrictedAccess"+item.Key, "Врагам не доступна комната "+item.Value, false, new string[]{item.Key});
            newActionFeature.callback += OnRestrictedAccessCallback;
            featureStorageRooms.TryAddActionFeature(newActionFeature);
        }
    }

    private void OnRestrictedAccessCallback(string[] parametersAction)
    {
        if (Rooms.Rooms.roomsDictionary.Keys.Contains(parametersAction[0]))
        {
            ReserveRoutes.SetReserveRoute(this);
        }
    }
}