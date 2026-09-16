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
        // Set animator velocity value
        playerAnimator.SetFloat("Velocity", rb.linearVelocity.magnitude);

        if (IsMoving())
        {
            // Get angle in degrees
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;

            // Avoid negative angles
            if (angle < 0)
            {
                angle += 360f;
            }

            int directionIndex = Mathf.FloorToInt((angle + 22.5f) / 45f) % 8;

            switch (directionIndex)
            {
                case 0:
                    playerAnimator.SetTrigger("Moving East");
                    break;
                case 1:
                    playerAnimator.SetTrigger("Moving NorthEast");
                    break;
                case 2:
                    playerAnimator.SetTrigger("Moving North");
                    break;
                case 3:
                    playerAnimator.SetTrigger("Moving NorthWest");
                    break;
                case 4:
                    playerAnimator.SetTrigger("Moving West");
                    break;
                case 5:
                    playerAnimator.SetTrigger("Moving SouthWest");
                    break;
                case 6:
                    playerAnimator.SetTrigger("Moving South");
                    break;
                case 7:
                    playerAnimator.SetTrigger("Moving SouthEast");
                    break;
            }

            // TODO Create set of direction triggers and then use settrigger(directiontriggers[directionindex])
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
