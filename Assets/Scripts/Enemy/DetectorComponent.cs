using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectorComponent : MonoBehaviour
{
    static Predicate<GameObject> defaultPredicate = (obj) => { return obj.CompareTag("Player"); };
    public float detectionRange = 3f; //range-only now
    Predicate<GameObject> detectionPredicate = defaultPredicate;
    
    public UnityAction<List<GameObject>> OnDetection;

    private void Update()
    {
        if (detectionPredicate == null) return;
        var allThingsInRange = Physics2D.OverlapCircleAll(transform.position, detectionRange);
        List<GameObject> detectedObjects = new List<GameObject>();
        for (int i = 0; i < allThingsInRange.Length; i++) if (detectionPredicate(allThingsInRange[i].gameObject)) detectedObjects.Add(allThingsInRange[i].gameObject);
        OnDetection(detectedObjects);
    }
    

    public void SetTagToDetect(string tag) { detectionPredicate = (obj) => { return obj.CompareTag(tag); }; }
    public void SetDetectionClause(Predicate<GameObject> predicate) { if (predicate == null) detectionPredicate = defaultPredicate; }
}
