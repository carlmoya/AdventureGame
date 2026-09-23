using TMPro;
using UnityEngine;

// Script written by Carl Moya

public class Dialogue : MonoBehaviour
{
    // Fields

    public Color dialogueBoxColor = Color.black;
    public Color dialogueTextColor = Color.white;

    [Space(15)]
    public string[] dialogueLines = new string[0];

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
