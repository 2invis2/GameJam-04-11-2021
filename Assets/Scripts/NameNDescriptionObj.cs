using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NameAndDescriptionObject", menuName = "ScriptableObjects/NameAndDescriptionObject")]
public class NameNDescriptionObj : ScriptableObject
{
    public List<NameDescriptionPair> data = new List<NameDescriptionPair>();
}
[System.Serializable]
public class NameDescriptionPair {
    public string nameField;
    [TextArea] public string descriptionField;
}