using System.Collections.Generic;

namespace MurphyInc.Core.Model.Interfaces
{
    public interface IFeatureStorage
    {
        IEnumerable<SettingsFeature> Settings { get; }
        IEnumerable<ActionFeature> Actions { get; }
    }
}
