using UnityEngine;
using System.Linq;

// Script written by Carl Moya

public class PlayerInteract : MonoBehaviour
{
    // Fields

    public float maxInteractionDistance = 2f;

    private PlayerInput playerInput;

    // Methods

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        CheckInteraction();
    }

    private void CheckInteraction()
    {
        // If the player tapped the screen
        if (playerInput.TappedWorldCoordinates(out Vector2 tappedWorldCoordinates))
        {
            // TODO Check if tapped world coordinates is within max interaction distance

            // TODO Search for closest interactible to tapped world coordinates

            // TODO trigger interactible method
        }
    }

    // Return Methods

    /*private bool FoundInteractible(out IInteractible interactible)
    {
        
    }*/
}
