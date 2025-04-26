using UnityEngine;

namespace FPS_Controller_Woyboy
{
    /// <summary>
    /// FPS_Controller interaction controller is a simple script that casts a raycast
    /// and checks for gameobjects that meets conditions of a layer, a matching tag, and a
    /// matching Interactable.cs script.
    /// 
    /// This script also checks for input based on the player's interaction. Additionally,
    /// you can easily modify this script to do specific things such as displaying a 
    /// pop-up, or make another raycast to trigger specific events without needing
    /// player input. Therefore, jumpscares!
    /// </summary>

    public class PlayerInteractionController : MonoBehaviour
    {
        public static PlayerInteractionController Instance; // Since this is focused on singleplayer, using static instances is fine.

        [Header("Raycasting")]
        [SerializeField] private LayerMask interactableMask;
        [SerializeField] private float interactRaycastDistance = 1.5f; // interaction distance

        private Interactable interactableTarget;
        private bool inRange = false;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            HandleInteractAndInput();
            Raycast();
        }

        private void HandleInteractAndInput()
        {
            if (!inRange || interactableTarget == null) return;

            if (Input.GetKeyDown(KeyCode.E)) // Trigger the interactable's interaction method on "E" press
            {
                interactableTarget.Interact();
            }
        }

        private void Raycast()
        {
            // Interaction
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,
                out hit, interactRaycastDistance, interactableMask))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    interactableTarget = hit.collider.GetComponentInParent<Interactable>();
                    inRange = true;
                }
            }
            else
            {
                interactableTarget = null;
                inRange = false;
            }
        }
    }
}