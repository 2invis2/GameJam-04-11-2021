using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Assets.Scripts.FeatureStorages;
using MurphyInc.Core.Interfaces.Generic;
using UnityEngine;

public class ReserveRoutes : PseudoSingletonMonoBehaviour<ReserveRoutes>
{
    [SerializeField] private List<NPCRoute> reservsInspector;
    private static List<NPCRoute> reservs;

    void Awake()
    {
        Invoke(nameof(Test), 2f);
        reservs = reservsInspector;
    }

    void Test()
    {
        FeatureStorageRooms.Instance.GetByName("RestrictedAccessServerRoom").IsEnable = true;
    }
    public static void SetReserveRoute(EnemyBase enemyBase)
    {
        var randomIndex = Random.Range(0, reservs.Count-1);
        EnemyDirector.Instance.MoveNPCByRoute(enemyBase, reservs[randomIndex]);
    }
}