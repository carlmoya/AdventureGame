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

        if (base.IsMoving())
        {
            // Get the angle of the rigidbody velocity in degrees
            float angleInDegrees = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;

            // Avoid negative angles
            if (angleInDegrees < 0) { angleInDegrees += 360f; }

            // Get the trigger that cooresponds to the angle's direction
            string desiredTrigger = directionTriggers[Mathf.FloorToInt((angleInDegrees + 22.5f) / 45f) % 8];

            playerAnimator.SetTrigger(desiredTrigger);
        }
    }

    // Return Methods

    protected override Vector2 TargetPosition()
    {
        // Return the pressed world position or the current position
        return playerInput.TryGetPressedWorldPosition(out Vector2 pressedWorldPosition) ? pressedWorldPosition : rb.position;
    }
}
