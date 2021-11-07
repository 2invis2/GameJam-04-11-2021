using System.Collections.Generic;
using MurphyInc.Core.Model;

namespace Assets.Scripts.FeatureStorages
{
    public sealed class FeatureStorageBoss
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageBoss()
        {
            instance = FeatureStorageMain.Instance;

            var features = new[]
            {
                 BossIsWalking
            };

            instance.AddRange(features);
        }

        private FeatureStorageBoss() { }

        public static FeatureStorage Instance => instance;

        public static readonly ActionFeature BossIsWalking = new ActionFeature(name: nameof(BossIsWalking), description: "Босс выходит из комнаты", isEnable: false, isAvailable:true, "RestrictedAccessBossOffice");

        public static IEnumerable<ActionFeature> Features => _features;

        private static ActionFeature[] _features =
            new ActionFeature[]
            {
                BossIsWalking
            };
    }
}
