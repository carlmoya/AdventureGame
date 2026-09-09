using UnityEngine;

// Carl Moya

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
        // TODO Overhaul line
        rb.MovePosition(MovementDirection() * speed * Time.fixedDeltaTime);
    }

    // Return Methods

    protected abstract Vector2 MovementDirection(); // Overwritten by inheritor classes

    protected virtual bool IsMoving()
    {
        // TODO Return true depending on value of MovementDirection();
        return false;
    }
}
