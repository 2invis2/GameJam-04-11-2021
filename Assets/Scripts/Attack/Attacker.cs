using System;
using System.Collections.Generic;
using Projectile;
using UnityEngine;

namespace Attack
{
    public class Attacker : MonoBehaviour, IAttacker
    {
        public List<Attack> attacks;

        public void Attack(Vector2 direction) {
            Attack(attacks, direction);
        }
        public void Attack(List<Attack> attacks)
        {
            CreateProjectile(attacks.Find(x => x.isEnable));
        }
        public void Attack(List<Attack> attacks, Vector2 direction)
        {
            CreateProjectile(attacks.Find(x => x.isEnable), direction);
        }

        private void CreateProjectile(Attack attack)
        {
            Instantiate(attack.projectile, transform.position, transform.rotation);

        }
        private void CreateProjectile(Attack attack, Vector2 direction)
        {
            var projectile = Instantiate(attack.projectile, transform.position, transform.rotation);
            projectile.GetComponent<ProjectileMovement>().sender = this.gameObject;
            projectile.transform.LookAt(projectile.transform.position + Vector3.forward, direction);

            
        }
    }
}