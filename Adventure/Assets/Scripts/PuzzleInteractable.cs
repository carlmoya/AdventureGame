using UnityEditor.VisionOS;
using UnityEngine;
using static Unity.VisualScripting.Member;

//PF
//Puzzle Interactions

public class PuzzleInteractable : BaseInteractable
{
    public AudioSource audioSource;

    public AudioClip invalidInteract;
    public AudioClip validInteract;
    public AudioClip doorOpen;
    public AudioClip talisman;

    public static int currentRiddle = 1;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Interact()
    {
        if(PuzzleInteractable.currentRiddle == 1)
        {
            if (gameObject.CompareTag("FreezerInvalid"))
            {
                audioSource.clip = invalidInteract;
                audioSource.Play();

                Debug.Log("FreezerInvalid Interaction Works");
            }
            if (gameObject.CompareTag("FreezerValid"))
            {
                audioSource.clip = validInteract;
                audioSource.Play();

                Debug.Log("FreezerValid Interaction Works");

                PuzzleInteractable.currentRiddle = 2;
            }
        }


        if (PuzzleInteractable.currentRiddle == 2)
        {
            if (gameObject.CompareTag("ProduceInvalid"))
            {
                audioSource.clip = invalidInteract;
                audioSource.Play();

                Debug.Log("ProduceInvalid Interaction Works");
            }
            if (gameObject.CompareTag("ProduceValid"))
            {
                audioSource.clip = validInteract;
                audioSource.Play();

                Debug.Log("ProduceValid Interaction Works");

                PuzzleInteractable.currentRiddle = 3;
            }
        }


        if (PuzzleInteractable.currentRiddle == 3)
        {
            if (gameObject.CompareTag("ShelvesInvalid"))
            {
                audioSource.clip = invalidInteract;
                audioSource.Play();

                Debug.Log("ShelvesInvalid Interaction Works");
            }
            if (gameObject.CompareTag("ShelvesValid"))
            {
                audioSource.clip = validInteract;
                audioSource.Play();

                Debug.Log("ShelvesValid Interaction Works");

                PuzzleInteractable.currentRiddle = 4;
            }
        }


        if (PuzzleInteractable.currentRiddle == 4)
        {
            if (gameObject.CompareTag("RegistersInvalid"))
            {
                audioSource.clip = invalidInteract;
                audioSource.Play();

                Debug.Log("RegistersInvalid Interaction Works");
            }
            if (gameObject.CompareTag("RegistersValid"))
            {
                audioSource.clip = validInteract;
                audioSource.Play();

                Debug.Log("RegistersValid Interaction Works");

                PuzzleInteractable.currentRiddle = 5;
            }
        }


        if (PuzzleInteractable.currentRiddle == 5)
        {
            if (gameObject.CompareTag("BathroomInvalid"))
            {
                audioSource.clip = invalidInteract;
                audioSource.Play();

                Debug.Log("BathroomInvalid Interaction Works");
            }
            if (gameObject.CompareTag("BathroomValid"))
            {
                audioSource.clip = validInteract;
                audioSource.Play();

                Debug.Log("BathroomValid Interaction Works");

                PuzzleInteractable.currentRiddle = 6;
            }
        }


        if (PuzzleInteractable.currentRiddle == 6)
        {
            if (gameObject.CompareTag("DoorInteract"))
            {
                audioSource.clip = doorOpen;
                audioSource.Play();

                Debug.Log("DoorInteract Works");
                Destroy(gameObject);
                PuzzleInteractable.currentRiddle = 7;
            }
        }


        if (PuzzleInteractable.currentRiddle == 7)
        {
            if (gameObject.CompareTag("TalismanCollect"))
            {
                audioSource.clip = talisman;
                audioSource.Play();

                Debug.Log("TalismanCollect Interaction Works");
            }
        }

    }
}