using UnityEngine;

// Script written by Carl "skrelpish" Moya

public abstract class BaseMovement : MonoBehaviour
{
    // Fields

    [Header("Inherited Settings")] [Space(15)]
    public float speed = 250f;

    protected Collider2D col;
    protected Rigidbody2D rb;

    // Methods

    protected virtual void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        Vector2 desiredDirection = (TargetPosition() - rb.position).normalized;

        Vector2 desiredVelocity = desiredDirection * speed * Time.fixedDeltaTime;

        rb.linearVelocity = desiredVelocity;
    }

    // Return Methods

    protected abstract Vector2 TargetPosition();

    protected virtual bool IsMoving()
    {
        bool isMoving = rb.linearVelocity.magnitude < 0.01f ? false : true;

        return isMoving;
    }
}
