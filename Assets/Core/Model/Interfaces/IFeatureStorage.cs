using System.Collections.Generic;

namespace MurphyInc.Core.Model.Interfaces
{
    public interface IFeatureStorage
    {
        IEnumerable<ActionFeature> Features { get; }
    }
}
