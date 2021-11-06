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

    public sealed class FeatureStorageRooms
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageRooms()
        {
            var settings = new[]
            {
                new SettingsFeature(name: "", description: "", isEnable: false),
            };

            var actions = new[]
            {
                ToiletNoMagic
            };

            instance = new FeatureStorage(actions);
        }

        private FeatureStorageRooms() { }

        public static FeatureStorage Instance => instance;
        public static IEnumerable<ActionFeature> Features => instance.Features;

        public static readonly ActionFeature ToiletNoMagic = new ActionFeature(name: nameof(ToiletNoMagic), description: "Запрет на магию в туалетах", isEnable: false);
        public static readonly ActionFeature ChillNoMelee = new ActionFeature(name: nameof(ChillNoMelee), description: "Запрет на драки в комнате отдыха", isEnable: true);
        public static readonly ActionFeature OpenspaceNoRange = new ActionFeature(name: nameof(OpenspaceNoRange), description: "Запрет на стрельбу в оупенспейсе", isEnable: false);
        
        
    }
}