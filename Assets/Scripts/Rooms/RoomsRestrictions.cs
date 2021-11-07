using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.FeatureStorages;
using Attack;
using UnityEngine;
using UnityEngine.AI;

public class RoomsRestrictions : MonoBehaviour
{
    private Action restore;
    private bool hasAttacker = false;
    private bool hasMelee = false;
    private bool hasRange = false;
    private bool hasMagic = false;
    private Attacker _attacker;

    private void Awake()
    {
        hasAttacker = gameObject.TryGetComponent(out Attacker att);
        _attacker = att;
        if (hasAttacker)
        {
            hasRange = _attacker.attacks.Exists(x => x.attackType == AttackType.RANGE);
            hasMelee = _attacker.attacks.Exists(x => x.attackType == AttackType.MELLEE);
            hasMagic = _attacker.attacks.Exists(x => x.attackType == AttackType.MAGIC);
        }
    }

    public void OnRoomChange(string newRoom)
    {
        restore?.Invoke();
        restore = null;
        if (hasAttacker)
        {
            if ((FeatureStorageRooms.ChillNoMelee.IsEnable) && (newRoom == "Chill"))
            {
                if (hasMelee)
                {
                    SwitchMeleeEnabled();
                    restore += SwitchMeleeEnabled;
                }
            }
            if ((FeatureStorageRooms.OpenspaceNoRange.IsEnable) && (newRoom == "Openspace"))
            {
                if (hasMelee)
                {
                    SwitchRangeEnabled();
                    restore += SwitchRangeEnabled;
                }
            }
            if ((FeatureStorageRooms.ToiletNoMagic.IsEnable) && (newRoom == "Toilet"))
            {
                if (hasMelee)
                {
                    SwitchMagicEnabled();
                    restore += SwitchMagicEnabled;
                }
            }


            if (FeatureStorageBoss.BossIsWalking.IsEnable && GetComponent<EnemyBase>().gameObject.CompareTag("Boss"))
            {
                ReserveRoutes.SetReserveRoute(GetComponent<EnemyBase>());
            }

            if (FeatureStorageRooms.Instance.GetByName("RestrictedAccess" + newRoom).IsEnable)
            {
                ReserveRoutes.SetReserveRoute(GetComponent<EnemyBase>());
                if (TryGetComponent(out EnemyChaser chaser))
                {
                    chaser.Unchase();
                }
            }

        }
    }

    private void SwitchMeleeEnabled()
    {
        SwitchByType(AttackType.MELLEE);
    }
    
    private void SwitchMagicEnabled()
    {
        SwitchByType(AttackType.MAGIC);
    }
    
    private void SwitchRangeEnabled()
    {
        SwitchByType(AttackType.RANGE);
    }

    private void SwitchByType(AttackType attackType)
    {
        var index = _attacker.attacks.FindIndex(x => x.attackType == attackType);
        if (index < 0) return;

        var att = _attacker.attacks[index];
        _attacker.attacks[index] = new Attack.Attack(att.form, att.attackType, att.projectile, att.range, !att.isEnable);
    }
    

    
}
