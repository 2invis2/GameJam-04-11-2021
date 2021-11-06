using System;
using MurphyInc.Core.Model.Interfaces;

namespace MurphyInc.Core.Model
{
    public class BaseFeature : IFeature 
    {

        public BaseFeature(string name, string description, bool isEnable = false)
        {
            IsEnable = isEnable;
            _name = name;
            _description = description;
        }

        /// <summary>
        /// Включено ли правило
        /// </summary>
        public bool IsEnable { 
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable = value;
                callback?.Invoke();
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

        public override int GetHashCode() => Name.GetHashCode();

        public event Action callback;
        private readonly string _name;
        private readonly string _description;
        private bool _isEnable;
        
    }
}
