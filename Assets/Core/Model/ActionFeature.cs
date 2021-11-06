using System;

namespace MurphyInc.Core.Model
{
    public sealed class ActionFeature : BaseFeature
    {
        public delegate void ActionFeatureAction(string[] actionParams);

        public ActionFeature(string name, string description, bool isEnable = false, params string[] actionParams)
            : base(name, description, isEnable)
        {
            _actionParams = actionParams;
        }

        public event ActionFeatureAction Action;

        public void InvokeIsEnable()
        {
            if (IsEnable)
            {
                Action?.Invoke(_actionParams);
            }
        }

        private  readonly string[] _actionParams;

        public ActionFeature Copy()
        {
            return new ActionFeature(Name, Description, IsEnable);
        }
    }
}
