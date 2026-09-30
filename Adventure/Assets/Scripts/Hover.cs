using UnityEngine;

// Script written by Carl Moya

public class Hover : MonoBehaviour
{
    // Fields

    [Header("Hover Settings")] [Space(15)]
    public Vector2 amplitudes = Vector2.zero;
    public Vector2 frequencies = Vector2.zero;

    [Header("Update Settings")] [Space(15)]
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
        UpdateLocalPosition();
        UpdateElapsedTime();
    }

    private void UpdateLocalPosition()
    {
        transform.localPosition = TargetPosition();
    }

    private void UpdateElapsedTime()
    {
        float deltaTime = useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;

        elapsedTime += deltaTime;
    }

    // Return Methods

    private Vector2 TargetPosition()
    {
        float targetX = midline.x + SinePoint(amplitudes.x, frequencies.x);
        float targetY = midline.y + SinePoint(amplitudes.y, frequencies.y);

        Vector2 targetPosition = new Vector2(targetX, targetY);

        return targetPosition;
    }

    private float SinePoint(float amplitude, float frequency)
    {
        float sinePoint = amplitude * Mathf.Sin(elapsedTime * frequency);

        return sinePoint;
    }
}
