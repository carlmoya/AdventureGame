using UnityEngine;
using UnityEngine.InputSystem;

// Script written by Carl Moya

public class PlayerMovement : MovementBase
{
    // Fields

    public InputActionAsset inputActions;

    protected InputAction pressAction;
    protected InputAction positionAction;

    protected Animator playerAnimator;

    // Methods

    protected virtual void OnEnable()
    {
        // Enable gameplay action map
        inputActions.FindActionMap("Gameplay").Enable();
    }

    protected virtual void OnDisable()
    {
        // Disable gameplay action map
        inputActions.FindActionMap("Gameplay").Disable();
    }

    protected virtual void Awake()
    {
        // Set reference to press action
        pressAction = InputSystem.actions.FindAction("Press");

        // Set reference to position action
        positionAction = InputSystem.actions.FindAction("Position");

        // Set reference to player animator
        playerAnimator = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {
        // Set player animator values
        SetPlayerAnimatorValues();
    }

    protected virtual void SetPlayerAnimatorValues()
    {
        // Set player animator velocity value
        playerAnimator.SetFloat("Velocity", rb.linearVelocity.magnitude);

        if (IsMoving() == true)
        {
            if (Mathf.Abs(rb.linearVelocity.x) > Mathf.Abs(rb.linearVelocity.y))
            {
                if (rb.linearVelocity.x > 0)
                {
                    playerAnimator.SetTrigger("Moving East");
                }
                else
                {
                    playerAnimator.SetTrigger("Moving West");
                }
            }
            else
            {
                if (rb.linearVelocity.y > 0)
                {
                    playerAnimator.SetTrigger("Moving North");
                }
                else
                {
                    playerAnimator.SetTrigger("Moving South");
                }
            }
        }
    }

    // Return Methods

    protected override Vector2 TargetPosition()
    {
        // If the press action is being performed
        if (pressAction.inProgress == true)
        {
            // Get the current screen coordinates
            Vector2 screenCoordinates = positionAction.ReadValue<Vector2>();

            // Convert screen coordinates to world space coordinates
            Vector3 worldCoordinates = Camera.main.ScreenToWorldPoint(new Vector3(screenCoordinates.x, screenCoordinates.y, Camera.main.nearClipPlane));

            // return the target world position
            return new Vector2(worldCoordinates.x, worldCoordinates.y);
        }
        else
        {
            // Return the current position of the rigid body
            return rb.position;
        }
    }
}
