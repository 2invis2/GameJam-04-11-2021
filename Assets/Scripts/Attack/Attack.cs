using System;
using UnityEngine;

namespace Attack
{
    [Serializable]
    public struct Attack
    {
        public AttackForm form;
        public AttackType attackType;
        public float range;
        public bool isEnable;
        public GameObject projectile;

        public Attack(AttackForm form, AttackType attackType, GameObject projectile, float range, bool isEnable)
        {
            this.attackType = attackType;
            this.projectile = projectile;
            this.range = range;
            this.isEnable = isEnable;
            this.form = form;
        }
    }
}