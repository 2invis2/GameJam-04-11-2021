using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Rooms
{
    public class Rooms : MonoBehaviour
    {
        private static List<Tilemap> roomsTilemaps;
        public static Dictionary<string, string> roomsDictionary;

        private void Awake()
        {
            roomsDictionary = new Dictionary<string, string>();
            roomsDictionary.Add("Toilet", "Туалет");
            roomsDictionary.Add("ServerRoom", "Серверная");
            roomsDictionary.Add("Reception", "Ресепшн");
            roomsDictionary.Add("Openspace", "Оупенспейс");
            roomsDictionary.Add("Chill", "Комната отдыха");
            roomsDictionary.Add("Dining", "Столовая");
            roomsDictionary.Add("Corridor", "Коридоры");
            roomsDictionary.Add("BossOffice", "Кабинет главы");
            roomsTilemaps = new List<Tilemap>();
            for (var i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).TryGetComponent(out Tilemap tm))
                {
                    roomsTilemaps.Add(tm);
                    
                }
            }
        }

        public static string GetRoomName(Vector3 coords)
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
    
        public static string GetRoomName(GameObject obj)
        {
            return GetRoomName(obj.transform);
        }
    
        public static string GetRoomName(Transform tr)
        {
            return GetRoomName(tr.position);
        }
    }
}
