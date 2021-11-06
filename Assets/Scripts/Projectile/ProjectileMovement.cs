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
            Destroy(gameObject);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerHP>().ProjectileHit(sender);
                Finished();
            }

            if (!other.gameObject.Equals(sender))
            {
                Debug.Log(other);
                Finished();
            }
                
        }

        private void Movement()
        {
            transform.position += transform.up * updateRatio * speed; 
        }
    }
}
