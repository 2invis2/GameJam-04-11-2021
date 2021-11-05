using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enemies;
using MurphyInc.Core;
using MurphyInc.Core.Interfaces.Generic;
using MurphyInc.Core.Model;
using MurphyInc.Core.Model.Interfaces;
using UnityEngine;

namespace Assets.Scripts.FeatureStorages
{

    public sealed class FeatureStorageEnemy
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageEnemy()
        {
            var settings = new[]
            {
                new SettingsFeature(name: "", description: "", isEnable: true),
                new SettingsFeature(name: "", description: "", isEnable: false),
                new SettingsFeature(name: "", description: "", isEnable: false),
                new SettingsFeature(name: "", description: "", isEnable: true),
            };

            var actions = new[]
            {
                new ActionFeature(name: "", description: "", isEnable: true),
                new ActionFeature(name: "", description: "", isEnable: false),
                new ActionFeature(name: "", description: "", isEnable: false),
                new ActionFeature(name: "", description: "", isEnable: true),
            };

            instance = new FeatureStorage(settings, actions);
        }

        private FeatureStorageEnemy() { }

        public static FeatureStorage Instance => instance;

        public static IEnumerable<SettingsFeature> Settings => instance.Settings;
        public static IEnumerable<ActionFeature> Actions => instance.Actions;
    }
}
