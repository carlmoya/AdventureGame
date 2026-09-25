using TMPro;
using UnityEngine;
using System.Collections;

// Script written by Carl Moya

public class DialogueBox : MonoBehaviour
{
    // Fields

    public float characterDisplayDelay = 0.025f;

    public AnimationCurve animationCurve;

    private TMP_Text text;
    private CanvasGroup canvasGroup;

    private GameObject player;

    // Methods

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        canvasGroup = GetComponent<CanvasGroup>();

        player = FindFirstObjectByType<PlayerMovement>().gameObject;

        canvasGroup.alpha = 0f;
    }

    // Coroutines

    public IEnumerator DisplayText(string inputText, Vector2 speakerPosition)
    {
        player.GetComponent<PlayerInput>().OnDisable();

        text.text = "";

        StartCoroutine(OpacityAnimation(1f));
        StartCoroutine(CameraMoveAnimation(new Vector3(speakerPosition.x, speakerPosition.y, -10f)));

        // Go thru characters in input text
        foreach (char character in inputText)
        {
            // Add character to text contents
            text.text += character;

            // Wait for character display delay
            yield return new WaitForSecondsRealtime(characterDisplayDelay);
        }

        yield return new WaitForSecondsRealtime(1f);

        player.GetComponent<PlayerInput>().OnEnable();

        StopAllCoroutines();

        StartCoroutine(OpacityAnimation(0f));
        StartCoroutine(CameraMoveAnimation(new Vector3(player.transform.position.x, player.transform.position.y, -10f)));
    }

    public IEnumerator OpacityAnimation(float targetOpacity)
    {
        float startOpacity = canvasGroup.alpha;

        for (float elapsedTime = 0f; elapsedTime < 0.5f; elapsedTime += Time.unscaledDeltaTime)
        {
            float time = elapsedTime / 0.5f;

            float currentAlpha = Mathf.Lerp(startOpacity, targetOpacity, animationCurve.Evaluate(time));

            canvasGroup.alpha = currentAlpha;

            yield return null;
        }

        canvasGroup.alpha = targetOpacity;
    }

    public IEnumerator CameraMoveAnimation(Vector3 targetPosition)
    {
        Vector3 startPosition = Camera.main.transform.position;

        for (float elapsedTime = 0f; elapsedTime < 0.5f; elapsedTime += Time.unscaledDeltaTime)
        {
            float time = elapsedTime / 0.5f;

            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, animationCurve.Evaluate(time));

            Camera.main.transform.position = currentPosition;

            yield return null;
        }

        Camera.main.transform.position = targetPosition;
    }
}
