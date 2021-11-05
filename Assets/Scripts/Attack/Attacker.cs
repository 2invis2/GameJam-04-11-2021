using System;
using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
    public class Attacker : MonoBehaviour, IAttacker
    {
        public List<Attack> attacks;

        public void Attack(List<Attack> attacks)
        {
            CreateProjectile(attacks.Find(x => x.isEnable));
        }

        private void CreateProjectile(Attack attack)
        {
            Instantiate(attack.projectile, transform.position, transform.rotation);
        }
    }
}