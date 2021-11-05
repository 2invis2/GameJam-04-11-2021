using System;
using System.Collections;
using UnityEngine;

namespace Rooms
{
    public class RoomWhereat : MonoBehaviour
    {
        [SerializeField] private string roomName;
        [SerializeField] private float updateRatio;

        private void Awake()
        {
            Invoke(nameof(SetNewRoomValue), updateRatio);
        }

        public void CheckRoomChange()
        {
            StartCoroutine(CheckingRoom());
        }

        IEnumerator CheckingRoom()
        {
            SetNewRoomValue();
            while (roomName == Rooms.GetRoomName(transform))
            {
                yield return new WaitForSeconds(updateRatio);
            }
            SetNewRoomValue();
        }

        private void SetNewRoomValue()
        {
            roomName = Rooms.GetRoomName(transform);
        }

        public string GetCurrentRoom()
        {
            return roomName;
        }
    }
}
