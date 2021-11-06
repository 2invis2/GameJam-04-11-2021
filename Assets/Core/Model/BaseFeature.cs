using System;
using MurphyInc.Core.Model.Interfaces;
using System.Collections.Generic;

namespace MurphyInc.Core.Model
{   
    public class BaseFeature : IFeature
    {
        public delegate void ActionFeatureAction(string[] actionParams);

        public BaseFeature(string name, string description, bool isEnable = false, params string[] actionParams)
        {
            IsEnable = isEnable;
            _name = name;
            _description = description;
            _actionParams = actionParams;
        }

        /// <summary>
        /// Включено ли правило
        /// </summary>
        public bool IsEnable
        {
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable = value;
                callback?.Invoke(_actionParams);
            }
        }

        /// <summary>
        /// Доступно ли правило
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                if (availableEvent != null)
                    return true;
                return availableEvent();
            }
        }

        /// <summary>
        /// Имя свойства
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// Описание правила
        /// </summary>
        public string Description => _description;

        public bool Equals(BaseFeature obj)
        {
            if (obj == null) return false;
            return GetHashCode() == obj.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return Equals((BaseFeature)obj);
        }
        public override int GetHashCode() => Name.GetHashCode();

        public event ActionFeatureAction callback;
        private readonly Func<bool> availableEvent;
        private readonly string _name;
        private readonly string _description;
        private bool _isEnable;
        protected readonly string[] _actionParams;
    }

    public class BaseFeatureComparer<TFeature> : IEqualityComparer<TFeature> where TFeature : BaseFeature
    {
        public bool Equals(TFeature x, TFeature y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(TFeature obj)
        {
            return obj.GetHashCode();
        }
    }
}
