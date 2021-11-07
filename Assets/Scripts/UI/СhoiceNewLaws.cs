using System.Collections.Generic;
using MurphyInc.Core.Model.Interfaces;
using UnityEngine;

public class СhoiceNewLaws : MonoBehaviour
{
    private List<IFeature> laws { get; set; }
    private IFeature choiceLaw;

    public void SetChoiceLaw(int indexLaw)
    {
        choiceLaw = laws[indexLaw];
    }

    public void AcceptChoiceLaw()
    {
        if (choiceLaw != null)
        {
        }
    }
}