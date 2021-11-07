using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.FeatureStorages;
using MurphyInc.Core.Model.Interfaces;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class СhoiceNewLaws : MonoBehaviour
{
    private List<IFeature> laws = new List<IFeature>();
    private static int countChoiceLaws = 3;
    private IFeature[] choicesLaws = new IFeature[countChoiceLaws];
    private IFeature choiceLaw;
    [SerializeField]
    private TextMeshProUGUI[] descriptionsChoicesLaws;

    void Start()
    {
        laws.Clear();
        foreach (var law in FeatureStorageMain.GetFeatures(false, true))
        {
            laws.Add(law);
            
        }

        choicesLaws = laws.OrderBy(item => Random.value).Take(countChoiceLaws).ToArray();
        
        for(var i = 0; i<countChoiceLaws; i++)
        {
            descriptionsChoicesLaws[i].SetText(choicesLaws[i].Description);
        }
    }
    
    public void SetChoiceLaw(int indexLaw)
    {
        choiceLaw = choicesLaws[indexLaw];
    }

    public void AcceptChoiceLaw()
    {
        if (choiceLaw != null)
        {
            choiceLaw.IsEnable = true;
            Invoke(nameof(StartGame), 5.0f);
        }
    }

    private void StartGame()
    {
        Application.LoadLevel(0);
    }
}