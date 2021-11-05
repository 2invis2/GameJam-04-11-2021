using System;
using UnityEngine;

namespace Attack
{
    [Serializable]
    public struct Attack
    {
        [SerializeField] private AttackType attackType;
        [SerializeField] private string projectile;
        [SerializeField] private float range;
        [SerializeField] private bool isEnable;
    }
}