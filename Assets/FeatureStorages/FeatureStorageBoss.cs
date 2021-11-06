using System.Collections.Generic;
using MurphyInc.Core.Model;

namespace Assets.Scripts.FeatureStorages
{

    public sealed class FeatureStorageBoss
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageBoss()
        {
            var features = new[]
            {
                 BossIsWalking
            };

            instance = new FeatureStorage(features);
        }

        private FeatureStorageBoss() { }

        public static FeatureStorage Instance => instance;

        public static IEnumerable<ActionFeature> Actions => instance.Features;

        public static readonly ActionFeature BossIsWalking = new ActionFeature(name: nameof(BossIsWalking), description: "Босс выходит из комнаты", isEnable: false);       
    }
}
