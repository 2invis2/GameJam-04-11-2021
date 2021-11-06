using Assets.Scripts.FeatureStorages;
using System;
using UnityEngine;

namespace Enemies
{
    public class BaseEnemySample : MonoBehaviour
    {
        protected FeatureStorage featureStorage = FeatureStorageEnemy.Instance;
        protected virtual void Start()
        {
            ActionFeatureInit();
        }

        private void ActionFeatureInit()
        {
            FeatureStorageEnemy.RandVelocity.Action += OnEnableRandVelocity;
        }

        private void OnEnableRandVelocity(string[] @params)
        {
            throw new NotImplementedException();
        }
    }

    public class SomeDerector : MonoBehaviour
    {
        private void Update()
        {
            FeatureStorageEnemy.RandVelocity.InvokeIsEnable();
        }
    }
}
