using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCRoute : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();
    public Transform GetNextPoint(Transform currentPoint) {
        int targetIndex = points.FindIndex((a) => a == currentPoint);
        if (targetIndex < 0)
        { //not on the route now
            //Move to an appropriate point
            //now: to the first one
            return points[0];
        }
        targetIndex++;
        if (targetIndex >= points.Count) targetIndex = 0;

        return points[targetIndex];
    }

    private void OnDrawGizmosSelected()
    {
        if (points.Count > 1) {
            for (int i = 0; i < points.Count - 1; i++) {
                Gizmos.DrawLine(points[i].position, points[i + 1].position);
            }
            Gizmos.DrawLine(points[0].position, points[points.Count-1].position);
        }
    }
}
