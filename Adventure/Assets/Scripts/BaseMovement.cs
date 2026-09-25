using UnityEngine;

// Script written by Carl "skrelpish" Moya

public abstract class BaseMovement : MonoBehaviour
{
    // Fields

    [Header("Inherited Settings")]
    [Space(15)]
    public float speed = 250f;

    protected Collider2D col;
    protected Rigidbody2D rb;

    // Methods

    protected virtual void Start() // Can be overwritten by inheritor classes
    {
        // Set reference to collider2D component
        col = GetComponent<Collider2D>();

        // Set reference to rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate() // Can be overwritten by inheritor classes
    {
        // Calculate desired direction using target position and current position
        Vector2 desiredDirection = (TargetPosition() - rb.position).normalized;

        // Move the rigidbody in the desired direction at a constant rate
        rb.linearVelocity = desiredDirection * speed * Time.fixedDeltaTime;
    }

    // Return Methods

    protected abstract Vector2 TargetPosition(); // Must be overwritten by inheritor classes

    protected virtual bool IsMoving() // Can be overwritten by inheritor classes
    {
        // Return true if the rigidbody has velocity in any direction
        return rb.linearVelocity.magnitude < 0.01f ? false : true;
    }
}
