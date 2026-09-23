using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Fields

    public InputActionAsset inputActions;

    [HideInInspector]
    public InputAction pressAction;

    [HideInInspector]
    public InputAction positionAction;

    [HideInInspector]
    public Vector2 lastTouchedWorldPosition;

    [HideInInspector]
    public Vector2 lastTouchedScreenPosition;

    // Methods

    private void OnEnable()
    {
        inputActions.FindActionMap("Gameplay").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Gameplay").Disable();
    }

    private void Awake()
    {
        pressAction = InputSystem.actions.FindAction("Press");
        positionAction = InputSystem.actions.FindAction("Position");
    }

    private void Update()
    {
        if (PressedWorldCoordinates(out Vector2 pressedWorldCoordinates))
        {
            lastTouchedWorldPosition = pressedWorldCoordinates;
        }

        if (PressedScreenCoordinates(out Vector2 pressedScreenCoordinates))
        {
            lastTouchedScreenPosition = pressedScreenCoordinates;
        }
    }

    // Return Methods

    public bool PressedWorldCoordinates(out Vector2 pressedWorldCoordinates)
    {
        if (PressedScreenCoordinates(out Vector2 pressedScreenCoordinates))
        {
            // Convert pressed screen coordinates to world space coordinates
            Vector3 worldSpaceCoordinates = Camera.main.ScreenToWorldPoint(new Vector3(pressedScreenCoordinates.x, pressedScreenCoordinates.y, Camera.main.nearClipPlane));

            pressedWorldCoordinates = new Vector2(worldSpaceCoordinates.x, worldSpaceCoordinates.y);

            return true;
        }
        else
        {
            pressedWorldCoordinates = Vector2.zero;

            return false;
        }
    }

    public bool PressedScreenCoordinates(out Vector2 pressedScreenCoordinates)
    {
        // If the player is pressing on the screen
        if (pressAction.inProgress == true)
        {
            // Set pressed screen coordinates to the value of the position action
            pressedScreenCoordinates = positionAction.ReadValue<Vector2>();

            return true;
        }
        else
        {
            pressedScreenCoordinates = Vector2.zero;

            return false;
        }
    }

    public bool TappedWorldCoordinates(out Vector2 tappedWorldCoordinates)
    {
        if (TappedScreenCoordinates(out Vector2 tappedScreenCoordinates))
        {
            // Convert pressed screen coordinates to world space coordinates
            Vector3 worldSpaceCoordinates = Camera.main.ScreenToWorldPoint(new Vector3(tappedScreenCoordinates.x, tappedScreenCoordinates.y, Camera.main.nearClipPlane));

            tappedWorldCoordinates = new Vector2(worldSpaceCoordinates.x, worldSpaceCoordinates.y);

            return true;
        }
        else
        {
            tappedWorldCoordinates = Vector2.zero;

            return false;
        }
    }

    public bool TappedScreenCoordinates(out Vector2 tappedScreenCoordinates)
    {
        if (pressAction.WasReleasedThisFrame() == true)
        {
            tappedScreenCoordinates = lastTouchedScreenPosition;

            return true;
        }
        else
        {
            tappedScreenCoordinates = Vector2.zero;

            return false;
        }
    }
}
