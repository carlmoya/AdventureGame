using UnityEngine;

// Script written by Carl Moya

public class Dialogue : MonoBehaviour, IInteractable
{
    // Fields

    public Color dialogueBoxColor = Color.black;
    public Color dialogueTextColor = Color.white;

    public string[] dialogueLines = new string[0];

    private int currentLine;
    private DialogueBox dialogueBox;

    // Methods

    public void Start()
    {
        // Set reference to dialogue box
        dialogueBox = FindFirstObjectByType<DialogueBox>();
    }

    void IInteractable.Interact()
    {
        StartCoroutine(dialogueBox.DisplayText(dialogueLines[currentLine], dialogueBoxColor, dialogueTextColor));

        // Iterate the current line
        currentLine++;
    }
}
