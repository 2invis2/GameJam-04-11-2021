using Assets.Scripts.FeatureStorages;
using MurphyInc.Core.Model;
using System;
using UnityEngine;

namespace Enemies
{
    public class BaseEnemy : MonoBehaviour
    {
        protected FeatureStorage featureStorage = FeatureStorageEnemy.Instance;

        public BaseEnemy()
        {
            featureStorage.GetByName<ActionFeature>("someAction").Action += OnSampleAction;
        }

        private void OnSampleAction()
        {
            throw new NotImplementedException();
        }
    }

    public class SampleEnemy : BaseEnemy
    {
        void ToDoSomething()
        {
            featureStorage.GetByName<ActionFeature>("someAction").InvokeIsEnable();
        }
    }

}
