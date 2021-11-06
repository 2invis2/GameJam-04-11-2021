using System.Collections.Generic;
using MurphyInc.Core.Model;

namespace Assets.Scripts.FeatureStorages
{

    public sealed class FeatureStorageEnemy
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageEnemy()
        {
            var features = new[]
            {
                 RandVelocity
            };

            instance = new FeatureStorage(features);
        }

        private FeatureStorageEnemy() { }

        public static FeatureStorage Instance => instance;

        public static IEnumerable<ActionFeature> Actions => instance.Features;

        public static readonly ActionFeature RandVelocity = new ActionFeature(name: nameof(RandVelocity), description: "Никто не контролируют свою скорость", isEnable: false);
        public static readonly ActionFeature ReactToMovement = new ActionFeature(name: nameof(ReactToMovement), description: "Тебя не замечают пока стоишь", isEnable: false);
        public static readonly ActionFeature CanBePushed = new ActionFeature(name: nameof(CanBePushed), description: "Противников можно толкать", isEnable: false);        
    }
}
