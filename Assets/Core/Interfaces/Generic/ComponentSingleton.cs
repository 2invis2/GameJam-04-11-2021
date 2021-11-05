using UnityEngine;

namespace MurphyInc.Core.Interfaces.Generic
{
    public class ComponentSingleton<T> 
        : Component where T : Component
    {
        private static readonly object _lock = new object();
        private static T instance;

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if(instance == null)
                        instance = FindObjectOfType<T>();

                    if (instance == null)
                    {
                        var obj = new GameObject("SingletonOf" + typeof(T).Name);
                        instance = obj.AddComponent<T>();
                        DontDestroyOnLoad(obj);
                    }
                    return instance;
                }
            }
        }
    }
}