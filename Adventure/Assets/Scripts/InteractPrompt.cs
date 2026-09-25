using UnityEngine;

// Script written by Carl Moya

public class InteractPrompt : MonoBehaviour
{
    // Fields

    public float opacityFadeSpeed = 5f;

    private SpriteRenderer spriteRenderer;
    private BaseInteractable interactable;

    // Methods

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactable = GetComponentInParent<BaseInteractable>();
    }

    private void Update()
    {
        // Move current opacity to target opacity
        float newOpacity = Mathf.MoveTowards(spriteRenderer.color.a, interactable.CanInteract() ? 1f : 0f, opacityFadeSpeed * Time.unscaledDeltaTime);

        // Apply new opacity to sprite renderer color
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newOpacity);
    }
}
