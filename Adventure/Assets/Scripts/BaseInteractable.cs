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
        bool WithinMaxInteractionDistance = DistanceFromPlayer() <= maxInteractionDistance ? true : false;

        return WithinMaxInteractionDistance;
    }

    public virtual float DistanceFromPlayer()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);

        return distanceFromPlayer;
    }
}
