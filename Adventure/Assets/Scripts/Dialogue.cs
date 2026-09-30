using UnityEngine;

// Script written by Carl Moya

public class Dialogue : BaseInteractable
{
    // Fields

    [Header("\nDialogue Settings")] [Space(15)]
    public string[] dialogueLines = new string[0];

    private TextBox textBox;

    // Methods

    protected override void Start()
    {
        base.Start();

        textBox = FindFirstObjectByType<TextBox>();
    }

    public override void Interact()
    {
        StartCoroutine(textBox.TextAnimation(CurrentLine(), transform.position));
    }

    public override bool CanInteract()
    {
        return textBox.isAnimating == false && base.WithinMaxInteractionDistance() == true && base.gameManager.isPaused == false;
    }

    // Return Methods

    public string CurrentLine()
    {
        return dialogueLines[CurrentLineIndex()];
    }

    public int CurrentLineIndex()
    {
        return PuzzleInteractable.currentRiddle - 1;
    }
}
