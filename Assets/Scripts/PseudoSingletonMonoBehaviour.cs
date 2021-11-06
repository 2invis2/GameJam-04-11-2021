using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoSingletonMonoBehaviour<T>: MonoBehaviour
    where T: MonoBehaviour
{
    static T _instance;
    public static T Instance
    {
        get {
            if (_instance == null)
            {
                _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
            }
            return _instance;
        }
    }
    public virtual void Awake()
    {
        if (_instance != null) { Destroy(this); return; }
        _instance = this as T;
    }
    public virtual void OnDestroy()
    {
        if (_instance == this) _instance = null;
    }
}
