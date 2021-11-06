using System;
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

        public void AddActionFeature(ActionFeature actionFeature)
        {
            if (_features.ContainsKey(actionFeature.Name))
                throw new Exception("Закон с таким именем уже добавлен!");
            _features.Add(actionFeature.Name, actionFeature);
        }

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
