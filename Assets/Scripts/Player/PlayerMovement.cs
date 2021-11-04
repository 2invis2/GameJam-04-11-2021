using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Player
{

    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField]
        private float velocityMultiplier = 10;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void SetVelocity(float xAxis, float yAxis)
        {
            Vector2 newVelocity = new Vector2(xAxis, yAxis).normalized;
            newVelocity *= velocityMultiplier;
            rb.velocity = newVelocity;
        }
    }
}
