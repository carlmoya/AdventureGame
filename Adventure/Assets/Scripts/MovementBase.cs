using UnityEngine;

// Script written by Carl Moya

public abstract class MovementBase : MonoBehaviour
{
    // Fields

    public float speed;

    protected Collider2D col;
    protected Rigidbody2D rb;

    // Methods

    protected virtual void Start()
    {
        // Set reference to collider
        col = GetComponent<Collider2D>();

        // Set reference to rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate() // Not ran every frame to avoid issues w/ physics
    {
        // Move the rigid body towards the target position
        rb.MovePosition(Vector2.MoveTowards(rb.position, TargetPosition(), speed * Time.fixedDeltaTime));
    }

    // Return Methods

    protected abstract Vector2 TargetPosition(); // Overwritten by inheritor classes

    protected virtual bool IsMoving()
    {
        // Return true depending on the magnitude of the rigid body velocity
        return rb.linearVelocity.magnitude < 0.01 ? false : true;
    }
}
