using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class MovementComponent : MonoBehaviour
{
    const float distEpsilon = 0.01f;

    private NavMeshAgent agent;
    [SerializeField] Transform target;
    public Transform Target { get => target; }
    public float MoveSpeed
    {
        get => Agent.speed;
        set => Agent.speed = value;
    }
    public NavMeshAgent Agent
    {
        get {
            if (agent == null) GetAgent();
            return agent;
        }
    }
    public UnityAction OnTargetReached;

    public void SetTarget(Transform newTarget) {
        target = newTarget;
        if (target != null)
        { 
            GetAgent();
            agent.SetDestination(target.position);
        }
    }
    private void Update()
    {
        float dist = agent.remainingDistance;
        if (dist < distEpsilon && (agent.pathStatus == NavMeshPathStatus.PathComplete)) OnTargetReached();
    }
    private void Start()
    {
        if (agent == null) GetAgent();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (agent == null) GetAgent();
    }
#endif
    private void GetAgent() { 
        agent = GetComponent<NavMeshAgent>();
    }
}
