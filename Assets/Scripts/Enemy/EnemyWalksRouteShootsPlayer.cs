using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attack;

public class EnemyWalksRouteShootsPlayer : EnemyBase
{
    public Attacker attacker;
    public float attackCD = 1f;
    [SerializeField] float attackCDLeft = 0f;
    protected override void Init()
    {
        base.Init();
        if (attacker == null) attacker = GetComponent<Attacker>();
    }
    protected override void DetectionResult(List<GameObject> foundObjects)
    {
        base.DetectionResult(foundObjects);
        if (foundObjects.Count > 0) TryDoAttack(foundObjects[0]); //attacker.Attack();
    }
    bool TryDoAttack(GameObject target)
    {
        if (attackCDLeft > 0f)
        {
            attackCDLeft -= Time.deltaTime;
            return false;
        }
        attacker.Attack(target.transform.position - transform.position);
        attackCDLeft = attackCD;
        return true;
    }
    protected override void GetParts()
    {
        base.GetParts();
        if (attacker == null) attacker = GetComponent<Attacker>();
    }
}
