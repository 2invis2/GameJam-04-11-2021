using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.FeatureStorages;
using UnityEngine;

public class InvokeEnabled : MonoBehaviour
{

    private void kek()
    {
        foreach (var elem in FeatureStorageMain.Features)
        {
            elem.CallBackInvoke();
        }
    }

    private void Awake()
    {
        StartCoroutine(corout());
    }

    IEnumerator corout()
    {
        yield return new WaitForSeconds(1f);
        kek();
        Debug.Log("work");
    }
}
