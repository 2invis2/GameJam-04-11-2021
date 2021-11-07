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
            _features = features
                .Distinct(new BaseFeatureComparer<ActionFeature>())
                .ToDictionary(x => x.Name, value => value);
        }

        public void AddRange(IEnumerable<ActionFeature> actionFeature)
        {
            var features = actionFeature.Distinct(new BaseFeatureComparer<ActionFeature>());
            foreach (var item in features)
            {
                TryAddActionFeature(item);
            }
        }

        public bool TryAddActionFeature(ActionFeature actionFeature)
        {
            if (_features.ContainsKey(actionFeature.Name))
                return false;
            _features.Add(actionFeature.Name, actionFeature);
            return true;
        }

        public bool Contains(ActionFeature actionFeature) => _features.ContainsKey(actionFeature.Name);

        public ActionFeature GetByName(string name)
        {
            if(_features.ContainsKey(name))
            {
                return _features[name];
            }
            return null;
        }

        public IEnumerable<ActionFeature> Features => _features.Values;

        private readonly Dictionary<string, ActionFeature> _features;
    }
}
