using System;
using UnityEngine;

namespace Projectile
{ 
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField] private float lifetime;
        [SerializeField] private float speed;
        [SerializeField] private float updateRatio;
        public GameObject sender;

        private void Awake()
        {
            Invoke(nameof(Finished), lifetime);
            InvokeRepeating(nameof(Movement), 0, updateRatio);
        }

        

        private void Finished()
        {
            Dead();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                transform.GetComponentInChildren<AudioControl>().OnDie();
                other.GetComponent<PlayerHP>().ProjectileHit(sender);
                Finished();
            }

            if (!other.gameObject.Equals(sender) && !other.gameObject.CompareTag("Projectile"))
            {
                transform.GetComponentInChildren<AudioControl>().OnDie();
                Finished();
            }
                
        }

        private void Movement()
        {
            transform.position += transform.up * updateRatio * speed; 
        }

        private void Dead()
        {
            Destroy(gameObject);
        }
    }
}
