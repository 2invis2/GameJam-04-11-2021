using System.Collections.Generic;
using System.Linq;
using MurphyInc.Core.Model;
using MurphyInc.Core.Model.Interfaces;

namespace Assets.Scripts.FeatureStorages
{
    public sealed class FeatureStorage : IFeatureStorage
    {
        public FeatureStorage(IEnumerable<SettingsFeature> settings, IEnumerable<ActionFeature> actions)
        {
            _settings = new HashSet<SettingsFeature>(settings);
            _actions = new HashSet<ActionFeature>(actions);
        }

        public IEnumerable<SettingsFeature> Settings => _settings;
        public IEnumerable<ActionFeature> Actions => _actions;

        private readonly HashSet<SettingsFeature> _settings;
        private readonly HashSet<ActionFeature> _actions;
    }
}
