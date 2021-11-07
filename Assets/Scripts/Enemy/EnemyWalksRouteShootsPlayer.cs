using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attack;

public class EnemyWalksRouteShootsPlayer : EnemyBase
{
    //public Attacker attacker;
    ////public float attackCD = 1f;
    ////[SerializeField] float cdLeft = 0f;
    //protected override void Init()
    //{
    //    base.Init();
    //    if (attacker == null) attacker = GetComponent<Attacker>();
    //}
    ////private void Update()
    ////{
    ////    if (cdLeft > 0f)
    ////    {
    ////        cdLeft -= Time.deltaTime;
    ////    }
    ////}
    //protected override void DetectionResult(List<GameObject> foundObjects)
    //{
    //    base.DetectionResult(foundObjects);
    //    if (foundObjects.Count > 0) attacker.TryAttack(foundObjects[0].transform.position); //attacker.Attack();
    //}
    ////bool TryDoAttack(GameObject target)
    ////{
    ////    if (cdLeft > 0f) return false;
    ////    if(attacker.TryAttack(target.transform.position))
    ////        cdLeft = attackCD;
    ////    return true;
    ////}
    //protected override void GetParts()
    //{
    //    base.GetParts();
    //    if (attacker == null) attacker = GetComponent<Attacker>();
    //}
}
