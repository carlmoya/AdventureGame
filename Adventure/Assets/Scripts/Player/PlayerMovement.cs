using UnityEngine;

// Script written by Carl Moya

public class PlayerMovement : BaseMovement
{
    // Fields

    protected PlayerInput playerInput;

    protected Animator playerAnimator;
    protected string[] directionTriggers = { "Move.E", "Move.NE", "Move.N", "Move.NW", "Move.W", "Move.SW", "Move.S", "Move.SE" };

    // Methods

    protected virtual void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {
        SetPlayerAnimatorValues();
    }

    protected virtual void SetPlayerAnimatorValues()
    {
        playerAnimator.SetFloat("Velocity", rb.linearVelocity.magnitude);

        if (IsMoving())
        {
            // Get the angle of the rigidbody linear velocity in degrees
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;

            // Avoid negative angles
            if (angle < 0) { angle += 360f; }

            // Set the trigger that cooresponds to the angle's compass direction
            playerAnimator.SetTrigger(directionTriggers[Mathf.FloorToInt((angle + 22.5f) / 45f) % 8]);
        }
    }

    // Return Methods

    protected override Vector2 TargetPosition() // Defined by base class
    {
        // Return any pressed world coordinates or the current position of the rigidbody
        return playerInput.PressedWorldCoordinates(out Vector2 pressedWorldCoordinates) ? pressedWorldCoordinates : rb.position;
    }
}
