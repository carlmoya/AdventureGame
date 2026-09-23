using UnityEngine;
using UnityEngine.InputSystem;

// Script written by Carl Moya

public class PlayerMovement : BaseMovement
{
    // TODO Clean up script

    // TODO Write comments

    // Fields

    protected PlayerInput playerInput;

    protected Animator playerAnimator;
    protected string[] directionTriggers = { "Move.E", "Move.NE", "Move.N", "Move.NW", "Move.W", "Move.SW", "Move.S", "Move.SE" };

    // Methods

    protected virtual void Awake()
    {
        // Set reference to player input
        playerInput = GetComponent<PlayerInput>();

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

            playerAnimator.SetTrigger(directionTriggers[directionIndex]);
        }
    }

    // Return Methods

    protected override Vector2 TargetPosition() // Defined by base class
    {
        return playerInput.PressedWorldCoordinates(out Vector2 pressedWorldCoordinates) ? pressedWorldCoordinates : rb.position;
    }
}
