using MurphyInc.Core.Model;
using System.Collections.Generic;

namespace Assets.Scripts.FeatureStorages
{
    public sealed class FeatureStorageProjectile
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageProjectile()
        {
            var actions = new ActionFeature[] { };

            instance = new FeatureStorage(actions);
        }

        private FeatureStorageProjectile() { }

        public static FeatureStorage Instance => instance;
        public static IEnumerable<ActionFeature> Actions => instance.Features;
    }
}