using UnityEngine;
using System.Linq;

// Script written by Carl Moya

public class PlayerInteract : MonoBehaviour
{
    // Fields

    private PlayerInput playerInput;

    // Methods

    private void Start()
    {
        // Set reference to player input component
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        // If the screen is tapped
        if (playerInput.TryGetTappedWorldPosition(out Vector2 tappedWorldPosition))
        {
            // If a valid interactable is found at the tapped world position
            if (FoundInteractable(tappedWorldPosition, out BaseInteractable interactable) && interactable.CanInteract() == true)
            {
                // Interact with the interactable
                interactable.Interact();
            }
        }
    }

    // Return Methods

    private bool FoundInteractable(Vector2 searchPosition, out BaseInteractable closestInteractable)
    {
        // Get all colliders within search radius
        closestInteractable = Physics2D.OverlapCircleAll(searchPosition, 0.5f)

            // Select interactable component
            .Select(otherCollider => otherCollider.GetComponent<BaseInteractable>())

            // Check that interactable component is not null
            .Where(interactable => interactable != null)

            // Sort by distance
            .OrderBy(interactable => Vector2.Distance((interactable).transform.position, searchPosition))

            // Set closest interactable
            .FirstOrDefault();

        // Return true if the closest interactable is not null
        return closestInteractable != null;
    }
}
