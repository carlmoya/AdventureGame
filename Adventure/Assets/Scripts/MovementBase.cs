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
        // Set the linear velocity of the rigid body
        rb.linearVelocity = (TargetPosition() - rb.position).normalized * speed * Time.fixedDeltaTime;
    }

    // Return Methods

    protected abstract Vector2 TargetPosition(); // Overwritten by inheritor classes

    protected virtual bool IsMoving()
    {
        // Return true depending on the magnitude of the current velocity of the rigid body
        return rb.linearVelocity.magnitude < 0.01f ? false : true;
    }
}
