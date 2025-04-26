using UnityEngine;
using UnityEngine.Events;

namespace FPS_Controller_Woyboy
{
    /// <summary>
    /// A simple but effective interactable class that can be easily modified and upgraded
    /// to your personal desires. Any objects that wishes to be interactable must inherit from this
    /// class. This script is the only class that works together with the 
    /// PlayerInteractionController.cs methods. Nothing else can control the Interact() method unless
    /// forced to by a different source.
    /// 
    /// </summary>

    public class Interactable : MonoBehaviour
    {
        [Header("Interactable")]
        [SerializeField] private bool canInteract = true;
        [SerializeField] private bool destroyOnInteract = false;
        [SerializeField] private float destroyDelay = .05f; // to give enough time for OnInteract to execute
        [SerializeField] private UnityEvent OnInteract;

        public virtual void Interact()
        {
            if (canInteract == false) return;

            OnInteract?.Invoke();

            if (destroyOnInteract == true)
            {
                Destroy(gameObject, destroyDelay);
            }
        }
    }
}
