using UnityEngine;

// Script written by Carl Moya

public class Hover : MonoBehaviour
{
    // Fields

    public Vector2 amplitudes = Vector2.one;
    public Vector2 frequencies = Vector2.one;

    public bool useUnscaledDeltaTime = false;

    private Vector2 midline;
    private float elapsedTime = 0f;

    // Methods

    private void Start()
    {
        midline = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = TargetPosition();

        elapsedTime += useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;
    }

    // Return Methods

    private Vector2 TargetPosition()
    {
        float targetX = midline.x + SinePoint(amplitudes.x, frequencies.x);
        float targetY = midline.y + SinePoint(amplitudes.y, frequencies.y);

        return new Vector2(targetX, targetY);
    }

    private float SinePoint(float amplitude, float frequency)
    {
        // Return a point on a sine wave
        return amplitude * Mathf.Sin(elapsedTime * frequency);
    }
}
