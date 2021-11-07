using System;
using System.Collections.Generic;
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
        foreach (var law in FeatureStorageMain.GetFeatures(false, true))
        {
            laws.Add(law);
            
        }
        Debug.Log(laws.Count);

        for (var i=0; i < countChoiceLaws; i++)
        {
            int rand;
            do
            {
                rand = Random.Range(0, laws.Count - 1);
            } while (Array.IndexOf(choicesLaws, laws[rand]) == -1);
                
            choicesLaws[i] = laws[rand];
        }

        for (int i = 0; i < countChoiceLaws; i++)
        {
            descriptionsChoicesLaws[i].text = choicesLaws[i].Description;
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
        }
    }
}