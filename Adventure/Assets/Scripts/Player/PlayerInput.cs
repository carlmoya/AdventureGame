using UnityEngine;
using UnityEngine.InputSystem;

// Script written by Carl Moya

public class PlayerInput : MonoBehaviour
{
    // Fields

    public InputActionAsset inputActions;

    public InputAction pressAction {  get; private set; }
    public InputAction positionAction { get; private set; }

    public Vector2 lastTouchedWorldPosition { get; private set; }
    public Vector2 lastTouchedScreenPosition { get; private set; }

    // Methods

    private void Awake()
    {
        pressAction = InputSystem.actions.FindAction("Press");
        positionAction = InputSystem.actions.FindAction("Position");
    }

    public void OnEnable()
    {
        inputActions.FindActionMap("Gameplay").Enable();
    }

    public void OnDisable()
    {
        inputActions.FindActionMap("Gameplay").Disable();
    }

    private void Update()
    {
        if (TryGetPressedScreenPosition(out Vector2 pressedScreenPosition))
        {
            lastTouchedScreenPosition = pressedScreenPosition;
            lastTouchedWorldPosition = ScreenPositionToWorldPosition(lastTouchedScreenPosition);
        }
    }

    // Return Methods

    public bool TryGetPressedScreenPosition(out Vector2 pressedScreenPosition)
    {
        // Return true and the pressed screen position if the screen is being pressed
        return (pressedScreenPosition = pressAction.inProgress ? positionAction.ReadValue<Vector2>() : Vector2.zero) != Vector2.zero;
    }

    public bool TryGetPressedWorldPosition(out Vector2 pressedWorldPosition)
    {
        // Return true and the pressed world position if the screen is being pressed
        return (pressedWorldPosition = TryGetPressedScreenPosition(out Vector2 pressedScreenPosition) ? ScreenPositionToWorldPosition(pressedScreenPosition) : Vector2.zero) != Vector2.zero;
    }

    public bool TryGetTappedScreenPosition(out Vector2 tappedScreenPosition)
    {
        // Return true and the tapped screen position if the press action was released this frame
        return (tappedScreenPosition = pressAction.WasReleasedThisFrame() ? lastTouchedScreenPosition : Vector2.zero) != Vector2.zero;
    }

    public bool TryGetTappedWorldPosition(out Vector2 tappedWorldPosition)
    {
        // Return true and the tapped world position if the press action was released this frame
        return (tappedWorldPosition = pressAction.WasReleasedThisFrame() ? lastTouchedWorldPosition : Vector2.zero) != Vector2.zero;
    }

    private Vector2 ScreenPositionToWorldPosition(Vector2 screenPosition)
    {
        // Convert screen position to world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));

        // Return world position
        return new Vector2(worldPosition.x, worldPosition.y);
    }
}
