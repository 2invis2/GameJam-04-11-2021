using System;
using Assets.Scripts.FeatureStorages;
using UnityEngine;

namespace Envt
{
    public class Sliding : MonoBehaviour
    {
        [SerializeField] private bool isSliding; 
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            if (gameObject.CompareTag("Table"))
                FeatureStorageEnv.SlidingTables.callback += OnCallbackSlidingTables;
            if (gameObject.CompareTag("Chairs"))
                FeatureStorageEnv.ConcreteChairs.callback += OnCallbackConcreteChairs;
            if (gameObject.CompareTag("Toilet"))
                FeatureStorageEnv.SlidingToilets.callback += OnCallbackSlidingToilets;
        }

        private void OnCallbackSlidingTables(string[] actionParams)
        {
            isSliding = FeatureStorageEnv.SlidingTables.IsEnable;
            RbSettings(isSliding);
        }
        
        private void OnCallbackConcreteChairs(string[] actionParams)
        {
            Debug.Log(FeatureStorageEnv.ConcreteChairs.IsEnable);
            if (FeatureStorageEnv.ConcreteChairs.IsEnable)
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
            Debug.Log(FeatureStorageEnv.ConcreteChairs.IsEnable);
        }
        
        private void OnCallbackSlidingToilets(string[] actionParams)
        {
            isSliding = FeatureStorageEnv.SlidingToilets.IsEnable;
            RbSettings(isSliding);
        }

        private void RbSettings(bool isDynamic)
        {
            rb.bodyType = isDynamic ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
            Debug.Log(rb.bodyType);
        }
    }
}
