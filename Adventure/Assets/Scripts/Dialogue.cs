using UnityEngine;

// Script written by Carl Moya

public class Dialogue : BaseInteractable
{
    // Fields

    [Header("Dialogue Settings")]
    [Space(15)]
    public string[] dialogueLines = new string[0];

    private int currentLine;
    private DialogueBox dialogueBox;

    // Methods

    protected override void Start()
    {
        // Run inherited behaviors
        base.Start();

        dialogueBox = FindFirstObjectByType<DialogueBox>();
    }

    public override void Interact()
    {
        StartCoroutine(dialogueBox.DisplayText(dialogueLines[currentLine]));

        // Iterate the current line
        currentLine++;
    }
}
