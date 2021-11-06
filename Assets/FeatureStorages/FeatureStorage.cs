using System.Collections.Generic;
using System.Linq;
using MurphyInc.Core.Model;
using MurphyInc.Core.Model.Interfaces;

namespace Assets.Scripts.FeatureStorages
{
    public sealed class FeatureStorage : IFeatureStorage
    {
        public FeatureStorage(IEnumerable<ActionFeature> features)
        {
            _features = new HashSet<ActionFeature>(features);
        }

        public IEnumerable<ActionFeature> Features => _features;

        private readonly HashSet<ActionFeature> _features;
    }
}
