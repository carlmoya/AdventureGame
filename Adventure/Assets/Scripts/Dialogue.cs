using UnityEngine;

// Script written by Carl Moya

public class Dialogue : BaseInteractable
{
    // Fields

    [Header("\nDialogue Settings")] [Space(15)]
    public string[] dialogueLines = new string[0];

    private TextBox textBox;
    private int currentLine = 0;

    // Methods

    protected override void Start()
    {
        base.Start();

        textBox = FindFirstObjectByType<TextBox>();
    }

    public override void Interact()
    {
        StartCoroutine(textBox.TextAnimation(dialogueLines[currentLine], transform.position));

        IterateLine();
    }

    public override bool CanInteract()
    {
        bool canInteract = textBox.isAnimating == false && base.WithinMaxInteractionDistance();

        return canInteract;
    }

    private void IterateLine()
    {
        if ((currentLine + 1) < dialogueLines.Length)
        {
            currentLine++;
        }
    }
}
