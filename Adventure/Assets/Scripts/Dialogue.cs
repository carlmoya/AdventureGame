using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    // Fields

    [Header("Dialogue Settings")]
    public string[] dialogueLines = new string[0];

    [Header("Color Settings")]
    public Color dialogueBoxColor = Color.black;
    public Color dialogueTextColor = Color.white;

    private int currentLine;
    private DialogueBox dialogueBox;

    // Methods

    public void Start()
    {
        // Set reference to dialogue box
        dialogueBox = FindFirstObjectByType<DialogueBox>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Speak();
        }
    }

    public void Speak()
    {
        StartCoroutine(dialogueBox.DisplayText(dialogueLines[currentLine], dialogueBoxColor, dialogueTextColor));

        // Iterate the current line
        currentLine++;
    }
}
