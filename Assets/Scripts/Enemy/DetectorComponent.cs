using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectorComponent : MonoBehaviour
{
    [SerializeField] float detectionRange = 3f;//range-only now
    [SerializeField] string tagToDetect;
    public UnityAction<List<GameObject>> OnDetection;

    private void Update()
    {
        if (tagToDetect.Length < 1) return;
        var allThingsInRange = Physics2D.OverlapCircleAll(transform.position, detectionRange);
        List<GameObject> detectedObjects = new List<GameObject>();
        for (int i = 0; i < allThingsInRange.Length; i++) if (allThingsInRange[i].gameObject.CompareTag(tagToDetect)) detectedObjects.Add(allThingsInRange[i].gameObject);
        OnDetection(detectedObjects);
    }
    public void SetTagToDetect(string tag) { tagToDetect = tag; }
}
