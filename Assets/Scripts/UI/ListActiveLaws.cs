using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.FeatureStorages;
using TMPro;
using UnityEngine;

public class ListActiveLaws : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI list;
    
    void Start()
    {
        UpdateListActiveLaws();
    }

    public void UpdateListActiveLaws()
    {
        string listLaws = "";
        
        foreach (var law in FeatureStorageMain.GetFeatures(true, true))
        {
            listLaws = listLaws + law.Description + "\n";
        }

        list.text = listLaws;
    }
}
