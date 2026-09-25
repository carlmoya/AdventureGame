using UnityEngine;

// Script written by Carl Moya

public class Hover : MonoBehaviour
{
    // Fields

    [Header("Hover Settings")]
    [Space(15)]
    public Vector2 amplitudes = Vector2.zero;
    public Vector2 frequencies = Vector2.zero;

    [Header("Update Settings")]
    [Space(15)]
    public bool useUnscaledDeltaTime = false;

    private Vector2 midline;
    private float elapsedTime = 0f;

    // Methods

    private void Start()
    {
        // Set midline to start position
        midline = transform.localPosition;
    }

    private void Update()
    {
        // Set current position to target position
        transform.localPosition = TargetPosition();

        // Update hover state according to update settings
        elapsedTime += useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;
    }

    // Return Methods

    private Vector2 TargetPosition()
    {
        // Calculate targetX using start position and sine point
        float targetX = midline.x + SinePoint(amplitudes.x, frequencies.x);

        // Calculate targetY using start position and sine point
        float targetY = midline.y + SinePoint(amplitudes.y, frequencies.y);

        // Return target position
        return new Vector2(targetX, targetY);
    }

    private float SinePoint(float amplitude, float frequency)
    {
        // Return a point on a sine wave
        return amplitude * Mathf.Sin(elapsedTime * frequency);
    }
}
