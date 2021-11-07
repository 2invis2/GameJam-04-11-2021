using MurphyInc.Core.Model;
using System.Collections.Generic;

namespace Assets.Scripts.FeatureStorages
{
    public sealed class FeatureStorageProjectile
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageProjectile()
        {
            instance = FeatureStorageMain.Instance;

            instance.AddRange(_features);
        }

        private FeatureStorageProjectile() { }

        public static FeatureStorage Instance => instance;

        public static IEnumerable<ActionFeature> Features => _features;

        private static ActionFeature[] _features =
            new ActionFeature[]
            {

            };
    }
}