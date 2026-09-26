using TMPro;
using UnityEngine;
using System.Collections;

// Script written by Carl Moya

public class DialogueBox : MonoBehaviour
{
    // Fields

    public float characterDisplayDelay = 0.025f;
    public float animationDuration = 0.5f;
    public AnimationCurve animationCurve;

    public bool isAnimating {  get; private set; }

    private TMP_Text text;
    private Transform player;
    private CanvasGroup canvasGroup;

    // Methods

    private void Start()
    {
        // Get reference to text component
        text = GetComponentInChildren<TMP_Text>();

        // Get reference to canvas group component
        canvasGroup = GetComponent<CanvasGroup>();

        // Get reference to player transform component
        player = GameObject.FindWithTag("Player").transform;

        // Hide dialogue box
        canvasGroup.alpha = 0f;

        // Scale down to 75%
        transform.localScale = Vector3.one * 0.75f;
    }

    // Coroutines

    public IEnumerator TextAnimation(string inputText, Vector2 speakerPosition)
    {
        // TODO Write comments
        // TODO Clean up method

        player.GetComponent<PlayerInput>().OnDisable();

        text.text = "";

        isAnimating = true;

        Time.timeScale = 0f;

        yield return StartCoroutine(TextBoxAnimation(1f, Vector3.one, new Vector3(speakerPosition.x, speakerPosition.y, -10f)));

        // Go thru characters in input text
        foreach (char character in inputText)
        {
            // Add character to text contents
            text.text += character;

            // Wait for character display delay
            yield return new WaitForSecondsRealtime(characterDisplayDelay);
        }

        yield return new WaitForSecondsRealtime(1f);

        //player.GetComponent<PlayerInput>().OnEnable();

        StopAllCoroutines();

        //isAnimating = false;

        Time.timeScale = 1f;

        yield return StartCoroutine(TextBoxAnimation(0f, Vector3.one * 0.75f, new Vector3(player.position.x, player.position.y, -10f)));

        isAnimating = false;

        player.GetComponent<PlayerInput>().OnEnable();
    }

    private IEnumerator TextBoxAnimation(float targetOpacity, Vector3 targetScale, Vector3 targetCameraPosition)
    {
        // Get start opacity from canvas group
        float startOpacity = canvasGroup.alpha;

        // Get start scale from transform
        Vector3 startScale = transform.localScale;

        // Get start camera position from main camera
        Vector3 startCameraPosition = Camera.main.transform.position;

        // Track & increase the elapsed time of the animation
        for (float elapsedTime = 0f; elapsedTime < animationDuration; elapsedTime += Time.unscaledDeltaTime)
        {
            // Normalize elapsed time
            float time = elapsedTime / animationDuration;

            // Interpolate opacity over time
            float currentOpacity = Mathf.Lerp(startOpacity, targetOpacity, animationCurve.Evaluate(time));

            // Apply current opacity to canvas group
            canvasGroup.alpha = currentOpacity;

            // Interpolate scale over time
            Vector3 currentScale = Vector3.Lerp(startScale, targetScale, animationCurve.Evaluate(time));

            // Apply current scale to transform
            transform.localScale = currentScale;

            // Interpolate camera position over time
            Vector3 currentCameraPosition = Vector3.Lerp(startCameraPosition, targetCameraPosition, animationCurve.Evaluate(time));

            // Apply current camera position to main camera
            Camera.main.transform.position = currentCameraPosition;

            // Wait for next frame
            yield return null;
        }

        // Ensure target opacity
        canvasGroup.alpha = targetOpacity;

        // Ensure target scale
        transform.localScale = targetScale;

        // Ensure target camera location
        Camera.main.transform.position = targetCameraPosition;
    }
}
