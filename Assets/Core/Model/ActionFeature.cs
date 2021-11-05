using System;

namespace MurphyInc.Core.Model
{
    public sealed class ActionFeature : BaseFeature
    {
        public ActionFeature(string name, string description, bool isEnable = false)
            : base(name, description, isEnable)
        { 
        }

        public event Action Action;

        public void InvokeIsEnable()
        {
            if (IsEnable)
            {
                Action.Invoke();
            }
        }
    }
}
