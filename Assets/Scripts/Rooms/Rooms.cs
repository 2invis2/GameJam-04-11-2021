using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Rooms : MonoBehaviour
{
    private List<Tilemap> roomsTilemaps;

    private void Awake()
    {
        roomsTilemaps = new List<Tilemap>();
        for (var i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out Tilemap tm))
            {
                roomsTilemaps.Add(tm);
            }
        }
    }

    public string GetRoomName(Vector3 coords)
    {
        string ans = null;
        foreach (Tilemap tm in roomsTilemaps)
        {
            if (tm.GetTile(tm.WorldToCell(coords)) != null)
            {
                ans = tm.gameObject.name;
                break;
            }

        }

        return ans;
    }
    
    public string GetRoomName(GameObject obj)
    {
        return GetRoomName(obj.transform);
    }
    
    public string GetRoomName(Transform tr)
    {
        return GetRoomName(tr.position);
    }
}
