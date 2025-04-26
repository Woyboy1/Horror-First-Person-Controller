using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

namespace FPS_Controller_Woyboy
{
    /// <summary>
    /// FPS_Controller for Horror uses rigid body based movement over CharacterController 
    /// because of the many factors you can control in the rigid body such as gravity, 
    /// velocity, etc. 
    /// 
    /// This controller also uses the old input system as it's simpler to read properties in script
    /// and I'm avoiding the use of event subscriptions to take up space.
    /// </summary>
    /// 

    public class PlayerMovement : MonoBehaviour
    {
        public static PlayerMovement Instance; // Since this is focused on singleplayer, using static instances is fine.

        private const float stepDelay = 0.55f;

        [Header("Assignables")]
        [SerializeField] private GameObject orientation; // for the player direction

        [Header("Assignables - Other")]
        [SerializeField] private ImpulseController headBobController; // for headbob;

        [Header("Settings - General")]
        [SerializeField] private float currentMovementSpeed = 3.5f; // avoid changing in inspector
        [SerializeField] private float sprintingSpeed = 6.0f;
        [SerializeField] private float walkingSpeed = 3.5f;

        [Header("Settings - Sprinting")]
        [SerializeField] private bool canSprint = false;

        private Vector3 targetVelocity;
        private Rigidbody rb;
        private float horizontal;
        private float vertical;
        private float moveTime;
        private bool canMove = true;

        public GameObject Orientation => orientation;

        public void SetCurrentMoveSpeed(float targetSpeed)
        {
            currentMovementSpeed = targetSpeed;
        }

        public void SetCanMove(bool canMove)
        {
            this.canMove = canMove;
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            GetMovementInput();
            FootstepImpact();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void GetMovementInput()
        {
            if (canMove == false) { return; }

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (Input.GetKey(KeyCode.LeftShift) && vertical >= 1 && canSprint == true)
            {
                SetCurrentMoveSpeed(sprintingSpeed); // Sprinting
            }
            else
            {
                SetCurrentMoveSpeed(walkingSpeed); // Walking
            }
        }

        private void MovePlayer()
        {
            if (canMove == false) return;

            Vector3 moveDir = orientation.transform.forward * vertical + orientation.transform.right * horizontal;
            moveDir = moveDir.normalized;

            targetVelocity = moveDir * currentMovementSpeed;

            // Preserve vertical movement (falling/jumping)
            targetVelocity.y = rb.linearVelocity.y;

            rb.linearVelocity = targetVelocity;
        }

        /// <summary>
        /// FootstepImpact() checks every step taken by the plaer and plays audio
        /// and camerabob when necessary. 
        /// </summary>
        private void FootstepImpact()
        {
            if (horizontal != 0 || vertical != 0)
            {
                float scaledDelay = stepDelay * (walkingSpeed / currentMovementSpeed); // scales with movement speed

                if (Time.time - moveTime < scaledDelay)
                    return; // cooldown

                moveTime = Time.time;

                headBobController.Shake();
                // Insert Audio Here
            }
        }
    }
}
