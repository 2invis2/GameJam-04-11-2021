
namespace MurphyInc.Core.Model
{
    public sealed class SettingsFeature : BaseFeature
    {
        public SettingsFeature(string name, string description, bool isEnable = false)
            : base(name, description, isEnable)
        {
        }
    }
}
