using TMPro;
using UnityEngine;
using System.Collections;

// Script written by Carl Moya

public class TextBox : MonoBehaviour
{
    // Fields

    [Header("Character Display Settings")] [Space(15)]
    public float characterDisplayDelay = 0.025f;

    [Header("Text Box Animation Settings")] [Space(15)]
    public float textBoxAnimationDuration = 0.5f;
    public AnimationCurve textBoxAnimationCurve;

    public bool isAnimating {  get; private set; }

    private TMP_Text text;
    private CanvasGroup canvasGroup;

    private Transform player;
    private GameManager gameManager;

    // Methods

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        canvasGroup = GetComponent<CanvasGroup>();

        player = GameObject.FindWithTag("Player").transform;
        gameManager = GameObject.FindFirstObjectByType<GameManager>();

        canvasGroup.alpha = 0f;
        transform.localScale = Vector3.one * 0.75f;
    }

    // Coroutines

    public IEnumerator TextAnimation(string inputText, Vector2 speakerPosition)
    {
        text.text = "";

        gameManager.DisablePause();

        isAnimating = true;

        Time.timeScale = 0f;

        yield return StartCoroutine(TextBoxAnimation(1f, Vector3.one, new Vector3(speakerPosition.x, speakerPosition.y, -10f)));

        yield return StartCoroutine(CharacterAnimation(inputText));

        yield return new WaitForSecondsRealtime(1f);

        yield return StartCoroutine(TextBoxAnimation(0f, Vector3.one * 0.75f, new Vector3(player.position.x, player.position.y, -10f)));

        Time.timeScale = 1f;

        isAnimating = false;

        gameManager.EnablePause();
    }

    private IEnumerator CharacterAnimation(string inputText)
    {
        foreach (char character in inputText)
        {
            text.text += character;

            yield return new WaitForSecondsRealtime(characterDisplayDelay);
        }
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
        for (float elapsedTime = 0f; elapsedTime < textBoxAnimationDuration; elapsedTime += Time.unscaledDeltaTime)
        {
            // Normalize elapsed time
            float time = elapsedTime / textBoxAnimationDuration;

            // Interpolate opacity over time
            float currentOpacity = Mathf.Lerp(startOpacity, targetOpacity, textBoxAnimationCurve.Evaluate(time));

            // Apply current opacity to canvas group
            canvasGroup.alpha = currentOpacity;

            // Interpolate scale over time
            Vector3 currentScale = Vector3.Lerp(startScale, targetScale, textBoxAnimationCurve.Evaluate(time));

            // Apply current scale to transform
            transform.localScale = currentScale;

            // Interpolate camera position over time
            Vector3 currentCameraPosition = Vector3.Lerp(startCameraPosition, targetCameraPosition, textBoxAnimationCurve.Evaluate(time));

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
