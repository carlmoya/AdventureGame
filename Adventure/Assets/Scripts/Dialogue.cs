using UnityEngine;

// Script written by Carl Moya

public class Dialogue : BaseInteractable
{
    // Fields

    [Header("\nDialogue Settings")]
    [Space(15)]
    public string[] dialogueLines = new string[0];

    private int currentLine = 0;
    private DialogueBox dialogueBox;

    // Methods

    protected override void Start() // Defined by base class
    {
        // Run inherited behaviors
        base.Start();

        // Set reference to dialogue box component
        dialogueBox = FindFirstObjectByType<DialogueBox>();
    }

    public override void Interact() // Defined by base class
    {
        // Tell dialogue box to animate text
        StartCoroutine(dialogueBox.TextAnimation(dialogueLines[currentLine], transform.position));

        // Iterate the current line if possible
        if (currentLine + 1 < dialogueLines.Length) { currentLine++; }
    }

    public override bool CanInteract() // Defined by base class
    {
        // Return true if the dialogue box is not animating and the current position is within the max interaction distance
        return dialogueBox.isAnimating == false && base.WithinMaxInteractionDistance();
    }
}
