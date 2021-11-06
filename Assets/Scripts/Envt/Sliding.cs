using System;
using Assets.Scripts.FeatureStorages;
using UnityEngine;

namespace Envt
{
    public class Sliding : MonoBehaviour
    {
        [SerializeField] private bool isSliding = false; 
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            FeatureStorageEnv.SlidingTables.callback += OnCallback;
            FeatureStorageEnv.SlidingTables.IsEnable = true;
        }

        private void OnCallback()
        {
            isSliding = FeatureStorageEnv.SlidingTables.IsEnable;
            RbSettings(isSliding);
        }

        private void RbSettings(bool isDynamic)
        {
            if (isDynamic)
                rb.bodyType = RigidbodyType2D.Dynamic;
            else
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
