using System;

namespace MurphyInc.Core.Model
{
    public sealed class ActionFeature : BaseFeature
    {       

        public ActionFeature(string name, string description, bool isEnable = false, bool isAvailable = true, params string[] actionParams)
            : base(name, description, isEnable, isAvailable, actionParams)
        {
           
        }

        public event ActionFeatureAction Action;

        public void InvokeIsEnable()
        {
            if (IsEnable)
            {
                Action?.Invoke(_actionParams);
            }
        }        

        public ActionFeature Copy()
        {
            return new ActionFeature(Name, Description, IsEnable);
        }
    }
}
