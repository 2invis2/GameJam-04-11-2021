using System;
using System.Collections.Generic;
using Projectile;
using UnityEngine;

namespace Attack
{
    public class Attacker : MonoBehaviour//, IAttacker
    {
        public List<Attack> attacks;

        public void Attack(Vector2 position) {
            Attack(attacks, position);
        }
        public void Attack(List<Attack> attacks, Vector2 position)
        {
            ResolveAttack(attacks.Find(x => x.isEnable), position);
        }

        private void ResolveAttack(Attack attack, Vector2 position) {
            switch (attack.form) {
                case AttackForm.Projectile:
                    CreateProjectile(attack, position);
                    break;
                case AttackForm.DelayedExplosionAtPoint:

                    break;
                default:
                    Debug.LogWarning("Tried to do unknown attack form: " + attack.form.ToString());
                    break;
            }
        }

        private void CreateProjectile(Attack attack, Vector2 position)
        {
            var projectile = Instantiate(attack.projectile, transform.position, transform.rotation);
            projectile.GetComponent<ProjectileMovement>().sender = this.gameObject;
            projectile.transform.LookAt(projectile.transform.position + Vector3.forward, position - (Vector2)transform.position);
        }
    }
}