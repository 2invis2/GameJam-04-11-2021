using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.FeatureStorages;
using UnityEngine;

public class ChangeDetection : MonoBehaviour
{
    private float baseDetection;
    [SerializeField]
    private float detectionChangeMultiplier;
    private DetectorComponent dc;

    private void Awake()
    {
        dc = GetComponent<DetectorComponent>();
        baseDetection = dc.detectionRange;
        FeatureStorageEnv.LesserFOV.callback+=OnCallbackLess;
        FeatureStorageEnv.BiggerFOV.callback+=OnCallbackBig;
    }
    
    private void OnCallbackLess()
    {
        if (FeatureStorageEnv.LesserFOV.IsEnable)
        {
            dc.detectionRange = baseDetection / detectionChangeMultiplier;
            FeatureStorageEnv.BiggerFOV.IsEnable = false;
        }
    }
    
    private void OnCallbackBig()
    {
        if (FeatureStorageEnv.BiggerFOV.IsEnable)
        {
            dc.detectionRange = baseDetection * detectionChangeMultiplier;
            FeatureStorageEnv.LesserFOV.IsEnable = false;
        }
    }
}
