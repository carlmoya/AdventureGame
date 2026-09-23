using UnityEngine;

// Script written by Carl "skrelpish" Moya

public abstract class BaseMovement : MonoBehaviour
{
    // Fields

    public float speed = 250f;

    protected Collider2D col;
    protected Rigidbody2D rb;

    // Methods

    protected virtual void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate() // Not ran every frame to avoid issues with physics
    {
        Vector2 desiredDirection = (TargetPosition() - rb.position).normalized;

        // Move the rigidbody in the desired direction at a constant rate
        rb.linearVelocity = desiredDirection * speed * Time.fixedDeltaTime;
    }

    // Return Methods

    protected abstract Vector2 TargetPosition(); // Overwritten by inheritor classes

    protected virtual bool IsMoving()
    {
        return rb.linearVelocity.magnitude < 0.01f ? false : true;
    }
}
