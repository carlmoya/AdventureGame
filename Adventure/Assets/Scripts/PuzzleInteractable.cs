using Unity.VisualScripting;
using UnityEditor.VisionOS;
using UnityEngine;
using static Unity.VisualScripting.Member;

//PHOEBE: player puzzle interactions

public class PuzzleInteractable : BaseInteractable
{
    public AudioSource audioSource;

    public AudioClip invalidInteract, validInteract, doorOpen, talisman;

    public static int currentRiddle = 1; //Initial riddle

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Interact()
    {
        if(PuzzleInteractable.currentRiddle == 1) //If on riddle 1, let player interact
        {
            if (gameObject.CompareTag("FreezerInvalid")) // If item is not located where player searched, play sound to indicate
            {
                audioSource.clip = invalidInteract;
                audioSource.Play();

                Debug.Log("FreezerInvalid Interaction Works");
            }
            if (gameObject.CompareTag("FreezerValid")) //If item is located where player searched, play sound to indicate and move player to next riddle
            {
                audioSource.clip = validInteract;
                audioSource.Play();

                Debug.Log("FreezerValid Interaction Works");

                PuzzleInteractable.currentRiddle = 2;
            }
        }


        if (PuzzleInteractable.currentRiddle == 2) //If on riddle 2, let player interact
        {
            if (gameObject.CompareTag("ProduceInvalid")) // If item is not located where player searched, play sound to indicate
            {
                audioSource.clip = invalidInteract;
                audioSource.Play();

                Debug.Log("ProduceInvalid Interaction Works");
            }
            if (gameObject.CompareTag("ProduceValid")) //If item is located where player searched, play sound to indicate and move player to next riddle
            {
                audioSource.clip = validInteract;
                audioSource.Play();

                Debug.Log("ProduceValid Interaction Works");

                PuzzleInteractable.currentRiddle = 3;
            }
        }


        if (PuzzleInteractable.currentRiddle == 3) //If on riddle 3, let player interact
        {
            if (gameObject.CompareTag("ShelvesInvalid")) // If item is not located where player searched, play sound to indicate
            {
                audioSource.clip = invalidInteract;
                audioSource.Play();

                Debug.Log("ShelvesInvalid Interaction Works");
            }
            if (gameObject.CompareTag("ShelvesValid")) //If item is located where player searched, play sound to indicate and move player to next riddle
            {
                audioSource.clip = validInteract;
                audioSource.Play();

                Debug.Log("ShelvesValid Interaction Works");

                PuzzleInteractable.currentRiddle = 4;
            }
        }


        if (PuzzleInteractable.currentRiddle == 4) //If on riddle 4, let player interact
        {
            if (gameObject.CompareTag("RegistersInvalid")) // If item is not located where player searched, play sound to indicate
            {
                audioSource.clip = invalidInteract;
                audioSource.Play();

                Debug.Log("RegistersInvalid Interaction Works");
            }
            if (gameObject.CompareTag("RegistersValid")) //If item is located where player searched, play sound to indicate and move player to next riddle
            {
                audioSource.clip = validInteract;
                audioSource.Play();

                Debug.Log("RegistersValid Interaction Works");

                PuzzleInteractable.currentRiddle = 5;
            }
        }


        if (PuzzleInteractable.currentRiddle == 5) //If on riddle 5, let player interact
        {
            if (gameObject.CompareTag("BathroomInvalid")) // If item is not located where player searched, play sound to indicate
            {
                audioSource.clip = invalidInteract;
                audioSource.Play();

                Debug.Log("BathroomInvalid Interaction Works");
            }
            if (gameObject.CompareTag("BathroomValid")) //If item is located where player searched, play sound to indicate and move player to next riddle
            {
                audioSource.clip = validInteract;
                audioSource.Play();

                Debug.Log("BathroomValid Interaction Works");

                PuzzleInteractable.currentRiddle = 6;
            }
        }


        if (PuzzleInteractable.currentRiddle == 6) //If on riddle 6, let player interact
        {
            if (gameObject.CompareTag("DoorInteract")) //Let player open door if all items are collected, play sound and destroy door object
            {
                audioSource.clip = doorOpen;
                audioSource.Play();

                Debug.Log("DoorInteract Works");
                Destroy(gameObject);
                PuzzleInteractable.currentRiddle = 7;
            }
        }
    }
}