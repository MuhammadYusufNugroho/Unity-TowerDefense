using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Reference new input system
    private MyInputs inputAction;
    // Reference Character Controller
    private CharacterController controller;
    // Refrence Animator
    private Animator animator;

    // Variable of Logic Movement
    bool isMovementPressed;
    bool isRunPressed;
    // Variable for Player Speed
    [SerializeField]
    private float speedMovement = 2f;
    [SerializeField]
    private float speedRun = 4f;
    // Variable for Player Vector
    private Vector2 currentInput;
    private Vector3 playerMovement;
    private Vector3 playerRunMovement;

    // Variable for Player Gravity
    [SerializeField]
    private float groundedGravity = -.05f;
    [SerializeField]
    private float gravity = -9.8f;

    // Logic for Player Jumping
    bool isJumpPressed = false;
    bool isJumping = false;
    // Variable for Player Jumping
    float initialJumpVelocity;
    float maxJumpHeight = 4.0f;
    float maxJumpTime = 0.75f;
    // Animator logic jumping
    bool isJumpAnimating;
    int jumpCount = 0;
    Dictionary<int, float> initialJumpVelocities = new Dictionary<int, float>();
    Dictionary<int, float> jumpGravities = new Dictionary<int, float>();

    int jumpCountHash;
    //int isJumpingHash;

    Coroutine currentJumpResetRoutine = null;

    // Enabling and Disabling Player Input action
    private void OnEnable() => inputAction.Player.Enable();
    private void OnDisable() => inputAction.Player.Disable();

    private void Awake()
    {
        // Get the reference components
        inputAction = new MyInputs();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        #region PlayerInput Regions
        // Player.Move
        inputAction.Player.Move.started += Move_Context;
        inputAction.Player.Move.performed += Move_Context;
        inputAction.Player.Move.canceled += Move_Context;
        // Player.Run
        inputAction.Player.Run.started += Run_Context;
        inputAction.Player.Run.canceled += Run_Context;
        // Player.Jump
        inputAction.Player.Jump.started += Jump_Context;
        inputAction.Player.Jump.canceled += Jump_Context;
        #endregion

        //animator reference
        jumpCountHash = Animator.StringToHash("jumpCount");

        // Handle SetupJumpVariable
        setupJumpVariable();
    }

    private void setupJumpVariable()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;

        float secondJumpGravitiy = (-2 * (maxJumpHeight + 2)) / Mathf.Pow((timeToApex * 1.25f), 2);
        float secondJumpInitialVelocity = (2 * (maxJumpHeight + 2)) / (timeToApex * 1.25f);

        float thirdJumpGravitiy = (-2 * (maxJumpHeight + 4)) / Mathf.Pow((timeToApex * 1.25f), 2);
        float thirdJumpInitialVelocity = (2 * (maxJumpHeight + 4)) / (timeToApex * 1.25f);

        initialJumpVelocities.Add(1, initialJumpVelocity);
        initialJumpVelocities.Add(2, secondJumpInitialVelocity);
        initialJumpVelocities.Add(3, thirdJumpInitialVelocity);

        jumpGravities.Add(0, gravity);
        jumpGravities.Add(1, gravity);
        jumpGravities.Add(2, secondJumpGravitiy);
        jumpGravities.Add(3, thirdJumpGravitiy);
    }

    private void Jump_Context(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Reference Player to read the button in input system
        //Debug.Log(isJumpPressed);
        isJumpPressed = context.ReadValueAsButton();
    }

    private void Run_Context(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Reference Player to read the button in input system
        //Debug.Log(isRunPressed);
        isRunPressed = context.ReadValueAsButton();
    }

    private void Move_Context(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Reference Player to change the vector2 axis to vector3 axis
        //Debug.Log(isMovePressed);
        currentInput = context.ReadValue<Vector2>();
        playerMovement = new Vector3(currentInput.x, 0, currentInput.y) * speedMovement;
        playerRunMovement = new Vector3(currentInput.x, 0, currentInput.y) * speedRun;

        // Creating The logic
        isMovementPressed = currentInput.x != 0 || currentInput.y != 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle Section
        HandelRotation();
        HandleAnimation();
        HandleMove();
        HandleGravity();
        HandleJump();
    }

    private void HandleJump()
    {
        if (!isJumping && controller.isGrounded && isJumpPressed)
        {
            if (jumpCount < 3 && currentJumpResetRoutine != null)
            {
                StopCoroutine(currentJumpResetRoutine);
            }
            //Set animation Jump
            animator.SetBool("isJumping", true);
            jumpCount += 1;
            animator.SetInteger(jumpCountHash, jumpCount);

            isJumpAnimating = true;
            isJumping = true;
            playerMovement.y = initialJumpVelocities[jumpCount] * 0.5f;
            playerRunMovement.y = initialJumpVelocities[jumpCount] * 0.5f;
        }
        else if (!isJumpPressed && isJumping && controller.isGrounded)
        {
            isJumping = false;
        }
    }

    IEnumerator jumpResetRoutine()
    {
        yield return new WaitForSeconds(.5f);
        jumpCount = 0;
    }

    private void HandleGravity()
    {
        bool isFalling = playerMovement.y <= 0.0f || !isJumpPressed;
        float fallMultiplayer = 2.0f;
        if (controller.isGrounded)
        {
            if (isJumpAnimating)
            {
                animator.SetBool("isJumping", false);
                isJumpAnimating = false;
                currentJumpResetRoutine = StartCoroutine(jumpResetRoutine());

                if (jumpCount == 3)
                {
                    jumpCount = 0;
                    animator.SetInteger(jumpCountHash, jumpCount);
                }
            }
            playerMovement.y = groundedGravity;
            playerRunMovement.y = groundedGravity;
        }
        else if (isFalling)
        {
            float previousYVelocity = playerMovement.y;
            float newYVelocity = playerMovement.y + (jumpGravities[jumpCount] * fallMultiplayer * Time.deltaTime);
            float nextYVelocity = Mathf.Max((previousYVelocity + newYVelocity) * 0.5f, -20.0f);
            playerMovement.y = nextYVelocity;
            playerRunMovement.y = nextYVelocity;
        }
        else
        {
            float previousYVelocity = playerMovement.y;
            float newYVelocity = playerMovement.y + (jumpGravities[jumpCount] * Time.deltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * 0.5f;
            playerMovement.y = nextYVelocity;
            playerRunMovement.y = nextYVelocity;
        }
    }

    private void HandleAnimation()
    {
        // Local Variable for animation
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");

        // Handle isWalking
        if (isMovementPressed && !isWalking)
            animator.SetBool("isWalking", true);
        else if (!isMovementPressed && isWalking)
            animator.SetBool("isWalking", false);
        //Handle isRunning
        if ((isMovementPressed && isRunPressed) && !isRunning)
            animator.SetBool("isRunning", true);
        else if ((!isMovementPressed || !isRunPressed) && isRunning)
            animator.SetBool("isRunning", false);
    }

    private void HandelRotation()
    {
        // Local variable for rotation
        Vector3 positionToLook = new Vector3(currentInput.x, 0, currentInput.y);
        Quaternion currentRotation = transform.rotation;
        float rotationSpeed = 10f;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLook);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void HandleMove()
    {
        // Logic if the run preseed using movement run, otherwise using simple move
        if (isRunPressed)
            controller.Move(playerRunMovement * Time.deltaTime);
        else
            controller.Move(playerMovement * Time.deltaTime);
    }
}
