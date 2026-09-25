using UnityEngine;
using System.Collections;

// Script written by Carl Moya

public class InteractPrompt : MonoBehaviour
{
    // Fields

    [Header("Interactable Settings")]
    [Space(15)]
    public BaseInteractable interactable;

    [Header("Animation Settings")]
    [Space(15)]
    public AnimationCurve animationCurve;
    public float animationDuration = 0.25f;

    private SpriteRenderer spriteRenderer;
    private bool canInteractStateLastFrame = false;

    // Methods

    private void Start()
    {
        // Set reference to sprite renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set opacity and scale to match can interact state last frame
        StartCoroutine(CanInteractStateAnimation(0f, Vector3.zero));
    }

    private void Update()
    {
        // Store can interact state
        bool canInteract = interactable.CanInteract();

        // If the current can interact state state has changed
        if (canInteract != canInteractStateLastFrame)
        {
            // Stop any animations
            StopAllCoroutines();

            // Set opacity and scale to match can interact state
            StartCoroutine(CanInteractStateAnimation(canInteract ? 1f : 0f, canInteract ? Vector3.one : Vector3.zero));

            // Update can interact state last frame
            canInteractStateLastFrame = canInteract;
        }
    }

    // Coroutines

    private IEnumerator CanInteractStateAnimation(float targetOpacity, Vector3 targetScale)
    {
        // Get start opacity from sprite renderer color
        float startOpacity = spriteRenderer.color.a;

        // Get start scale from transform
        Vector3 startScale = transform.localScale;

        // Track & increase the elapsed time of the animation
        for (float elapsedTime = 0f; elapsedTime < animationDuration; elapsedTime += Time.unscaledDeltaTime)
        {
            // Normalize elasped time
            float time = elapsedTime / animationDuration;

            // Interpolate opacity over time
            float currentOpacity = Mathf.Lerp(startOpacity, targetOpacity, animationCurve.Evaluate(time));

            // Apply current opacity to sprite renderer color
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, currentOpacity);

            // Interpolate scale over time
            Vector3 currentScale = Vector3.Lerp(startScale, targetScale, animationCurve.Evaluate(time));

            // Apply current scale to transform
            transform.localScale = currentScale;

            // Wait for next frame
            yield return null;
        }

        // Ensure target opacity
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, targetOpacity);

        // Ensure target scale
        transform.localScale = targetScale;
    }
}
