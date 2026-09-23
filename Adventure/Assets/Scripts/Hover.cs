using UnityEngine;

// Script written by Carl Moya

public class Hover : MonoBehaviour
{
    // Fields

    [Header("Hover Settings")]
    public Vector2 frequencies = Vector2.one;
    public Vector2 amplitudes = Vector2.one;

    [Header("Update Settings")]
    public bool useUnscaledDeltaTime = false;

    private Vector2 midline;
    private float elapsedTime = 0f;

    // Methods

    private void Start()
    {
        // Set midline
        midline = transform.localPosition;
    }

    private void Update()
    {
        // Increase the elapsed time
        elapsedTime += useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;

        // Set the current position
        transform.localPosition = TargetPosition();
    }

    // Return Methods

    private Vector2 TargetPosition()
    {
        // Get the target x position
        float targetX = midline.x + SinePoint(amplitudes.x, frequencies.x);

        // Get the target y position
        float targetY = midline.y + SinePoint(amplitudes.y, frequencies.y);

        // Return the target position
        return new Vector2(targetX, targetY);
    }

    private float SinePoint(float amplitude, float frequency)
    {
        // Return a point on a sine wave
        return amplitude * Mathf.Sin(elapsedTime * frequency);
    }
}
