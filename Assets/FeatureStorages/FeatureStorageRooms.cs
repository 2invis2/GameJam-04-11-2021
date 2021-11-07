using System.Collections.Generic;
using MurphyInc.Core.Model;

namespace Assets.Scripts.FeatureStorages
{

    public sealed class FeatureStorageRooms
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageRooms()
        {
            instance = FeatureStorageMain.Instance;
            instance.AddRange(_features);
        }

        private FeatureStorageRooms() { }

        public static FeatureStorage Instance => instance;

        public static readonly ActionFeature ToiletNoMagic = new ActionFeature(name: nameof(ToiletNoMagic), description: "Запрет на магию в туалетах", isEnable: false);
        public static readonly ActionFeature ChillNoMelee = new ActionFeature(name: nameof(ChillNoMelee), description: "Запрет на драки в комнате отдыха", isEnable: false);
        public static readonly ActionFeature OpenspaceNoRange = new ActionFeature(name: nameof(OpenspaceNoRange), description: "Запрет на стрельбу в оупенспейсе", isEnable: false);

        public static IEnumerable<ActionFeature> Features => _features;

        private static ActionFeature[] _features =
            new[]
            {
                ToiletNoMagic,
                ChillNoMelee,
                OpenspaceNoRange
            };
    }
}