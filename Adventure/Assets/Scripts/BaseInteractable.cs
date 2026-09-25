using UnityEngine;

// Script written by Carl Moya

public abstract class BaseInteractable : MonoBehaviour
{
    // Fields

    [Header("Interact Prompt Settings")]
    [Space(15)]
    public bool showInteractPrompt = true;
    public GameObject interactPromptPrefab;
    public float interactPromptVerticalOffset = 1f;

    protected PlayerInteract playerInteract;

    // Methods

    protected virtual void Start()
    {
        playerInteract = FindFirstObjectByType<PlayerInteract>();

        if (showInteractPrompt == true)
        {
            // Spawn interact prompt as a child of this transform
            Instantiate(interactPromptPrefab, transform.position + (Vector3.up * interactPromptVerticalOffset), Quaternion.identity, transform);
        }
    }

    public abstract void Interact(); // Overwritten by inheritor classes

    // Return Methods

    public virtual bool CanInteract()
    {
        return WithinMaxInteractionDistance();
    }

    public virtual bool WithinMaxInteractionDistance()
    {
        // Return true if the interactable is within the max interaction distance
        return Vector2.Distance(transform.position, playerInteract.transform.position) < playerInteract.maxInteractionDistance;
    }
}
