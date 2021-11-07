using System;
using System.Collections.Generic;
using Projectile;
using UnityEngine;

namespace Attack
{
    public class Attacker : MonoBehaviour//, IAttacker
    {
        public float attackCD = 1f;
        [SerializeField] float cdLeft = 0f;
        public List<Attack> attacks;

        private void Update()
        {
            if (cdLeft > 0f)
            {
                cdLeft -= Time.deltaTime;
            }
        }

        #region PerformingAttack
        public bool TryAttack(Vector2 position) {
            return TryAttack(attacks, position);
        }
        /// <summary>
        /// Пытается провести атаку, возвращает true если хотя бы одна была проведена. Если ни одна атака не была проведена - возвращает false
        /// </summary>
        /// <param name="attacks">Каким набором атак пытаться бить</param>
        /// <param name="position">Куда бить</param>
        /// <returns></returns>
        public bool TryAttack(List<Attack> attacks, Vector2 position)
        {
            if (cdLeft > 0f) return false;
            cdLeft = attackCD;
            var dist = (position - (Vector2)transform.position).magnitude;
            bool success = false;
            foreach (var atk in attacks.FindAll(x => x.isEnable && x.range >= dist)) 
            { 
                ResolveAttack(atk, position);
                success = true;
            }
            return success;
        }

        private void ResolveAttack(Attack attack, Vector2 position) {
            switch (attack.form) {
                case AttackForm.Projectile:
                    CreateProjectile(attack, position);
                    break;
                case AttackForm.DelayedExplosionAtPoint:
                    CreateAoE(attack, position);
                    break;
                default:
                    //Debug.LogWarning("Tried to do unknown attack form: " + attack.form.ToString());
                    break;
            }
        }

        private void CreateProjectile(Attack attack, Vector2 position)
        {
            var projectile = Instantiate(attack.projectile, transform.position, transform.rotation);
            projectile.GetComponent<ProjectileMovement>().sender = this.gameObject;
            projectile.transform.LookAt(projectile.transform.position + Vector3.forward, position - (Vector2)transform.position);
        }
        private void CreateAoE(Attack attack, Vector2 position) {
            var aoe = Instantiate(attack.projectile, position, transform.rotation);
            aoe.GetComponent<AoEAppearAndBlow>().sender = this.gameObject;
        }
        #endregion
    }
}