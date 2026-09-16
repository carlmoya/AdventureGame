using UnityEngine;

// Script written by Carl Moya

public class Hover : MonoBehaviour
{
    // Fields

    public float frequency = 1f;
    public float amplitude = 1f;

    private float startY;
    private float elapsedTime = 0f;

    // Methods

    private void Start()
    {
        startY = transform.localPosition.y;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        transform.localPosition = new Vector2(transform.localPosition.x, startY + Mathf.Sin(elapsedTime * frequency) * amplitude);
    }
}
