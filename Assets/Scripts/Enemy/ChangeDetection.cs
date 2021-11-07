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
        FeatureStorageEnv.LesserFOV.callback+= OnCallbackLess;
        FeatureStorageEnv.BiggerFOV.callback += OnCallbackBig;
        FeatureStorageEnv.LesserFOV.CallBackInvoke();
        FeatureStorageEnv.BiggerFOV.CallBackInvoke();
    }

    private void OnCallbackLess(string[] actionParams)
    {
        if (FeatureStorageEnv.LesserFOV.IsEnable)
        {
            dc.detectionRange = baseDetection / detectionChangeMultiplier;
            FeatureStorageEnv.BiggerFOV.IsEnable = false;
        }
    }
    
    private void OnCallbackBig(string[] actionParams)
    {
        if (FeatureStorageEnv.BiggerFOV.IsEnable)
        {
            dc.detectionRange = baseDetection * detectionChangeMultiplier;
            FeatureStorageEnv.LesserFOV.IsEnable = false;
        }
    }

    private void OnDestroy()
    {
        FeatureStorageEnv.LesserFOV.callback -= OnCallbackLess;
        FeatureStorageEnv.BiggerFOV.callback -= OnCallbackBig;
    }
}
