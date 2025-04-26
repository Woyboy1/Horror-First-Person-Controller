using Unity.Cinemachine;
using UnityEngine;

namespace FPS_Controller_Woyboy
{
    /// <summary>
    /// FPS_Controller uses the POV mechanic of the cinemachine package. While some people says that
    /// this function isn't that reliable, I believe it's still very strong and saves lots of time.
    /// 
    /// You can easily manipulate the values of the POV aim of the cinemachine camera which makes it very
    /// versatile. 
    /// 
    /// As of this time, the Cinemachine package changed the name of Aim for POV to Camera Tilt:
    /// * POV Aim --> CinemachinePanTilt
    /// 
    /// </summary>
    public class PlayerCameraController : MonoBehaviour
    {
        public static PlayerCameraController Instance; // Since this is focused on singleplayer, using static instances is fine.

        [Header("Assignables - General")]
        [SerializeField] private CinemachinePanTilt cameraPanTilt;

        private GameObject bodyToRotate; // store player orientation

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            bodyToRotate = PlayerMovement.Instance.Orientation;
            HideMouseCursor();
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            // float horizontalAxis = cinemachineCamera.m_HorizontalAxis.Value;
            float horizontalAxis = cameraPanTilt.PanAxis.Value;

            bodyToRotate.transform.rotation = Quaternion.Euler(0, horizontalAxis, 0);
        }

        public void HideMouseCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void ShowMouseCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
