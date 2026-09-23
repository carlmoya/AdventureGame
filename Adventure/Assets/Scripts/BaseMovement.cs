using UnityEngine;

// Script written by Carl Moya

public abstract class BaseMovement : MonoBehaviour
{
    // Fields

    public float speed = 250f;

    protected Collider2D col;
    protected Rigidbody2D rb;

    // Methods

    protected virtual void Start()
    {
        // Set collider reference
        col = GetComponent<Collider2D>();

        // Set rigidbody reference
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate() // Not ran every frame to avoid issues with physics
    {
        // Get the desired movement direction
        Vector2 desiredMovementDirection = (TargetPosition() - rb.position).normalized;

        // Move the rigidbody in the direction of the desired movement at a constant rate
        rb.linearVelocity = desiredMovementDirection * speed * Time.fixedDeltaTime;
    }

    // Return Methods

    protected abstract Vector2 TargetPosition(); // Overwritten by inheritor classes

    protected virtual bool IsMoving()
    {
        // Return true based on the magnitude of the linear velocity of the rigidbody
        return rb.linearVelocity.magnitude < 0.01f ? false : true;
    }
}
