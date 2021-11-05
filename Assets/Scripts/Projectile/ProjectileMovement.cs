using System;
using UnityEngine;

namespace Projectile
{ 
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField] private float lifetime;
        [SerializeField] private float speed;
        [SerializeField] private float updateRatio;
        private bool isCollided = false;

        private void Awake()
        {
            Invoke(nameof(Finished), lifetime);
            InvokeRepeating(nameof(Movement), 0, updateRatio);
        }

        private bool IsSuitableCollision(GameObject otherGameObject)
        {
            return true;
        }

        private void Finished()
        {
            Destroy(gameObject);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (IsSuitableCollision(other.gameObject))
            {
                isCollided = true;
                Finished();
                Destroy(other.gameObject);
            }
                
        }

        private void Movement()
        {
            transform.position += Vector3.up * updateRatio * speed;
        }
    }
}
