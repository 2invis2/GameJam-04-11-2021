
namespace MurphyInc.Core.Model.Interfaces
{
    public interface IFeature
    {
        bool IsEnable { get; set; }

        bool IsAvailable { get; }

        string Description { get; }
    }
}
