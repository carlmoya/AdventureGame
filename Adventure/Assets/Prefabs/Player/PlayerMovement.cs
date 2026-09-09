using UnityEngine;
using UnityEngine.InputSystem;

// Carl Moya

public class PlayerMovement : MovementBase
{
    // Fields

    protected InputAction movementAction;

    // Methods

    protected override void Start()
    {
        // Run inherited behaviors
        base.Start();

        // TODO Figure this out
        //movementAction = InputSystem.actions.FindAction("Movement");
    }

    protected virtual void Update() // Ran every frame
    {
        
    }

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
