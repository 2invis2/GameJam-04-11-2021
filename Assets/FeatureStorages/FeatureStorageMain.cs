
using MurphyInc.Core.Model;
using MurphyInc.Core.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.FeatureStorages
{
    public sealed class FeatureStorageMain
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageMain()   
        {

        }

        private FeatureStorageMain() { }

        public static FeatureStorage Instance => new FeatureStorage(new ActionFeature[] {});

        public static IEnumerable<ActionFeature> Features => instance.Features;

        public static IEnumerable<IFeature> GetFeatures(bool isEnable, bool isAvailable)
        {
            return instance.Features.Where(x => x.IsEnable == isEnable && x.IsAvailable == isAvailable);
        }

        public static  readonly Dictionary<string, IEnumerable<ActionFeature>> KnownActionFeatures = new Dictionary<string, IEnumerable<ActionFeature>>
            {
                { nameof(FeatureStorageEnemy), FeatureStorageEnemy.Features },
                { nameof(FeatureStorageEnv), FeatureStorageEnv.Features },
                { nameof(FeatureStorageRooms), FeatureStorageRooms.Features },
                { nameof(FeatureStorageProjectile), FeatureStorageEnemy.Features },
                { nameof(FeatureStorageEnemy), FeatureStorageEnemy.Features },
            };
    }
}
