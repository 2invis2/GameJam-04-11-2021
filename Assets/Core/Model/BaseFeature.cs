using System;
using MurphyInc.Core.Model.Interfaces;
using System.Collections.Generic;
using Assets.Scripts.FeatureStorages;

namespace MurphyInc.Core.Model
{
    public class BaseFeature : IFeature
    {
        public delegate void ActionFeatureAction(string[] actionParams);

        public BaseFeature(string name, string description, bool isEnable = false, bool isAvailable = true, params string[] actionParams)
        {
            IsEnable = isEnable;
            _name = name;
            _description = description;
            _actionParams = actionParams;
            _availableCondition = () => isAvailable;
        }

        public void CallBackInvoke()
        {
            if(IsEnable)
            {
                callback?.Invoke(_actionParams);
                needCallBack = false;
            }
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
                //TODO: Переписать логику на взаимоисключающие законы
                if(Equals(FeatureStorageEnv.BiggerFOV) && value)
                {
                    FeatureStorageEnv.LesserFOV.IsEnable = false;
                }
                if (Equals(FeatureStorageEnv.LesserFOV) && value)
                {
                    FeatureStorageEnv.BiggerFOV.IsEnable = false;
                }

                _isEnable = value;
            }
        }

        private bool needCallBack = false;

        /// <summary>
        /// Доступно ли правило
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                if (_availableCondition == null)
                    return true;
                return _availableCondition();
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
        public override int GetHashCode() =>  (Name ?? "").GetHashCode();

        public event ActionFeatureAction callback;
        public readonly Func<bool> _availableCondition;
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
