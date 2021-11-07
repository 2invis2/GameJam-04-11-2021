using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
    [System.Serializable]
    public class AttackBase
    {
        public AttackType type;
        public virtual AttackForm Form() => AttackForm.Unknown;
        public virtual void Attack(Transform target)
        {

        }
    }
}
