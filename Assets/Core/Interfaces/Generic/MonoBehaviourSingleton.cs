using UnityEngine;

namespace MurphyInc.Core.Interfaces.Generic
{
    public class MonoBehaviourSingleton<T> 
        : ComponentSingleton<T> where T : MonoBehaviour
    {
    }
}