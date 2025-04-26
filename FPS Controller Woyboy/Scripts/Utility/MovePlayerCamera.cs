using UnityEngine;


namespace FPS_Controller_Woyboy
{
    /// <summary>
    /// Because of the architecture of the player, moving the camera makes it easier
    /// to keep it clean and keep the camera attached to the player head.
    /// </summary>

    public class MovePlayerCamera : MonoBehaviour
    {
        public Transform target;

        void Update()
        {
            transform.position = target.position;
        }
    }
}