using UnityEngine;

// Script written by Carl Moya

public abstract class BaseInteractable : MonoBehaviour
{
    // Fields

    [Header("Inherited Settings")] [Space(15)]
    public float maxInteractionDistance = 5f;

    protected Transform player;
    protected GameManager gameManager;

    // Methods

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }

    public abstract void Interact();

    // Return Methods

    public virtual bool CanInteract()
    {
        return WithinMaxInteractionDistance() && gameManager.isPaused == false;
    }

    public virtual bool WithinMaxInteractionDistance()
    {
        return DistanceFromPlayer() <= maxInteractionDistance ? true : false;
    }

    public virtual float DistanceFromPlayer()
    {
        return Vector2.Distance(transform.position, player.position);
    }
}
