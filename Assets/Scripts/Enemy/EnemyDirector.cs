using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirector : MonoBehaviour
{
    [SerializeField] List<NpcAndRoute> control = new List<NpcAndRoute>();
    private void Start()
    {
        for (int i = 0; i < control.Count; i++) SetupNpcOnRoute(control[i].npc, control[i].route);
    }
    public void MoveNPCByRoute(EnemyBase npc, NPCRoute route) {
        if (npc == null) return;
        var controlIndex = control.FindIndex((con) => { return con.npc == npc; });
        if (controlIndex >= 0) control.RemoveAt(controlIndex);
        SetupNpcOnRoute(npc, route);
        if (route != null) control.Add(new NpcAndRoute(npc, route));
    }
    void SetupNpcOnRoute(EnemyBase npc, NPCRoute route) {
        if (npc == null) return;
        if (route == null) {
            npc.SetTarget(null);
            npc.OnMovementTargetReached = default;
            return;
        }
        npc.SetTarget(route.GetNextPoint(npc.MovementTarget));
        npc.OnMovementTargetReached = GiveNextTarget;
    }
    void GiveNextTarget(EnemyBase npc) {
        //Debug.Log("trying to give new point...");
        int npcIndex = 0;
        for (npcIndex = 0; npcIndex < control.Count; npcIndex++) if (control[npcIndex].npc == npc) break;
        if (npcIndex < control.Count)
        {
            npc.SetTarget(control[npcIndex].route.GetNextPoint(npc.MovementTarget));
        }
        else {
            Debug.Log("No next point for " + npc.gameObject.name);
        }
    }
}
[System.Serializable]
public class NpcAndRoute {
    public EnemyBase npc;
    public NPCRoute route;
    public NpcAndRoute() { }
    public NpcAndRoute(EnemyBase newNpc, NPCRoute newRoute) { npc = newNpc; route = newRoute; }
} 