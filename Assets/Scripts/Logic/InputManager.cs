using System;
using Player;
using UnityEngine;

namespace Logic
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovement playerMovement;

        private void Update()
        {
            playerMovement.SetVelocity(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}
