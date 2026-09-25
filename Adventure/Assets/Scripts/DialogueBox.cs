using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Script written by Carl Moya

public class DialogueBox : MonoBehaviour
{
    // TODO Prevent dialogues from triggering while displaying text

    // Fields

    public float characterDisplayDelay = 0.05f;

    private Image box;
    private TMP_Text text;

    // Methods

    private void Start()
    {
        // Set reference to box
        box = GetComponent<Image>();

        // Set reference to text
        text = GetComponentInChildren<TMP_Text>();
    }

    // Coroutines

    public IEnumerator DisplayText(string inputText)
    {
        // Reset text contents
        text.text = "";

        // TODO Wait for camera move animation

        // TODO Wait for box visibility animation

        // Go thru characters in input text
        foreach (char character in inputText)
        {
            // Add character to text contents
            text.text += character;

            // Wait for character display delay
            yield return new WaitForSecondsRealtime(characterDisplayDelay);
        }

        // TODO Wait for box visibility animation

        // TODO Wait for camera move animation
    }

    public IEnumerator boxVisibilityAnimation()
    {
        yield return null;
    }

    public IEnumerator CameraMoveAnimation()
    {
        yield return null;
    }
}
