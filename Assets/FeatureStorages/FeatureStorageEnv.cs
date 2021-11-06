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

    public sealed class FeatureStorageEnv
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageEnv()
        {
            var settings = new[]
            {
                new SettingsFeature(name: "", description: "", isEnable: false),
            };

            var actions = new[]
            {
                SlidingTables
            };

            instance = new FeatureStorage(settings, actions);
        }

        private FeatureStorageEnv() { }

        public static FeatureStorage Instance => instance;

        public static IEnumerable<SettingsFeature> Settings => instance.Settings;
        public static IEnumerable<ActionFeature> Actions => instance.Actions;

        public static readonly ActionFeature SlidingTables = new ActionFeature(name: nameof(SlidingTables), description: "Столы скользят по полу", isEnable: true);
    }
}