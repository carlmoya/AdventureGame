using UnityEngine;
using System.Linq;

// Script written by Carl Moya

public class PlayerInteract : MonoBehaviour
{
    // Fields

    public float maxInteractionDistance = 5f;

    private PlayerInput playerInput;

    // Methods

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        // If the screen is tapped and the tapped world position is within the max interaction distance
        if (playerInput.TryGetTappedWorldPosition(out Vector2 tappedWorldPosition) && Vector2.Distance(transform.position, tappedWorldPosition) < maxInteractionDistance)
        {
            // If an interactable if found at the tapped world position and can be interacted with
            if (FoundInteractable(tappedWorldPosition, out BaseInteractable interactable) && interactable.CanInteract() == true)
            {
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
            .OrderBy(interactable => Vector2.Distance(((MonoBehaviour)interactable).transform.position, searchPosition))

            // Set closest interactable
            .FirstOrDefault();

        return closestInteractable != null;
    }
}
