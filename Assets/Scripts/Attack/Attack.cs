using System;
using UnityEngine;

namespace Attack
{
    [Serializable]
    public struct Attack
    {
        public AttackType attackType;
        public GameObject projectile;
        public float range;
        public bool isEnable;
        
        public Attack(AttackType attackType, GameObject projectile, float range, bool isEnable)
        {
            this.attackType = attackType;
            this.projectile = projectile;
            this.range = range;
            this.isEnable = isEnable;
        }
    }
}