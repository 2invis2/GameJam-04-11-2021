using Player;
using UnityEngine;

namespace UI
{
    public class UITriggerZone : MonoBehaviour
    {
        [SerializeField] private GameObject ui;

        private void Awake()
        {
            ui.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerMovement pm))
            {
                ui.SetActive(true);
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerMovement pm))
            {
                ui.SetActive(false);
            }
        }
    }
}
