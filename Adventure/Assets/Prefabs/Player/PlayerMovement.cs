using UnityEngine;
using UnityEngine.InputSystem;

// Script written by Carl Moya

public class PlayerMovement : MovementBase
{
    // Fields

    public InputActionAsset inputActions;

    protected InputAction pressAction;
    protected InputAction positionAction;

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
