using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.FeatureStorages;
using UnityEngine;

public class PlayerFOV : MonoBehaviour
{
    private Camera cameraCurr;
    [SerializeField]
    private float cameraBaseSize;

    [SerializeField] private float FOVMultiplier;

    private void Awake()
    {
        cameraCurr = GetComponent<Camera>();
        cameraCurr.orthographicSize = cameraBaseSize;
        FeatureStorageEnv.LesserFOV.callback+=OnCallbackLess;
        FeatureStorageEnv.BiggerFOV.callback+=OnCallbackBig;
    }

    private void OnCallbackLess(string[] actionParams)
    {
        if (FeatureStorageEnv.LesserFOV.IsEnable)
        {
            cameraCurr.orthographicSize = cameraBaseSize / FOVMultiplier;
            FeatureStorageEnv.BiggerFOV.IsEnable = false;
        }
    }
    
    private void OnCallbackBig(string[] actionParams)
    {
        if (FeatureStorageEnv.BiggerFOV.IsEnable)
        {
            cameraCurr.orthographicSize = cameraBaseSize * FOVMultiplier;
            FeatureStorageEnv.LesserFOV.IsEnable = false;
        }
    }
}
