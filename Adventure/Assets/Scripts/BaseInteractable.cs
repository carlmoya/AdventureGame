using UnityEngine;

// Script written by Carl Moya

public abstract class BaseInteractable : MonoBehaviour
{
    // Fields

    [Header("Inherited Settings")]
    [Space(15)]
    public float maxInteractionDistance = 5f;

    protected PlayerInteract playerInteract;

    // Methods

    protected virtual void Start() // Can be overwritten by inheritor classes
    {
        // Set reference to player interact component
        playerInteract = FindFirstObjectByType<PlayerInteract>();
    }

    public abstract void Interact(); // Must be overwritten by inheritor classes

    // Return Methods

    public virtual bool CanInteract()
    {
        // Return true if the interactable is within the max interaction distance
        return WithinMaxInteractionDistance();
    }

    public virtual bool WithinMaxInteractionDistance()
    {
        // Return true if the interactable is within the max interaction distance
        return Vector2.Distance(transform.position, playerInteract.transform.position) < maxInteractionDistance;
    }
}
