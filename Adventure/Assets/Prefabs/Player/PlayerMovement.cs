using UnityEngine;

public class PlayerMovement : MovementBase
{
    // Return Methods

    protected override Vector2 MovementDirection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return Vector2.one;
        }
        else
        {
            return Vector2.zero;
        }
    }
}
