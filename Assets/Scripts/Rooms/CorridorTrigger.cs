using System;
using UnityEngine;

namespace Rooms
{
    public class CorridorTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out RoomWhereat roomWhereat))
            {
                roomWhereat.CheckRoomChange();
            }
        }
    }
}
