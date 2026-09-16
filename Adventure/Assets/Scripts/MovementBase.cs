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
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate() // Not ran every frame to avoid issues w/ physics
    {
        rb.linearVelocity = (TargetPosition() - rb.position).normalized * speed * Time.fixedDeltaTime;
    }

    // Return Methods

    protected abstract Vector2 TargetPosition(); // Overwritten by inheritor classes

    protected virtual bool IsMoving()
    {
        return rb.linearVelocity.magnitude < 0.01f ? false : true;
    }
}
