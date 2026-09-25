using UnityEngine;

// Script written by Carl Moya

public class PlayerMovement : BaseMovement
{
    // Fields

    protected PlayerInput playerInput;

    protected Animator playerAnimator;
    protected string[] directionTriggers = { "Move.E", "Move.NE", "Move.N", "Move.NW", "Move.W", "Move.SW", "Move.S", "Move.SE" };

    // Methods

    protected virtual void Awake() // Can be overwritten by inheritor classes
    {
        // Set reference to player input component
        playerInput = GetComponent<PlayerInput>();

        // Set reference to animator component
        playerAnimator = GetComponentInChildren<Animator>();
    }

    protected virtual void Update() // Can be overwritten by inheritor classes
    {
        SetPlayerAnimatorValues();
    }

    protected virtual void SetPlayerAnimatorValues() // Can be overwritten by inheritor classes
    {
        // Set animator velocity value to the current velocity
        playerAnimator.SetFloat("Velocity", rb.linearVelocity.magnitude);

        // If the rigidbody has velocity in any direction
        if (base.IsMoving())
        {
            // Get the angle of the rigidbody velocity in degrees
            float angleInDegrees = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;

            // Avoid negative angles
            if (angleInDegrees < 0) { angleInDegrees += 360f; }

            // Set the trigger that cooresponds to the angle's direction
            playerAnimator.SetTrigger(directionTriggers[Mathf.FloorToInt((angleInDegrees + 22.5f) / 45f) % 8]);
        }
    }

    // Return Methods

    protected override Vector2 TargetPosition() // Defined by base class
    {
        // Return the pressed world position or the current position
        return playerInput.TryGetPressedWorldPosition(out Vector2 pressedWorldPosition) ? pressedWorldPosition : rb.position;
    }
}
