using UnityEngine;

//PF
//Puzzle Interactions

public class PuzzleInteractable : BaseInteractable
{
    public static int currentRiddle = 1;

    public override void Interact()
    {
        if(PuzzleInteractable.currentRiddle == 1)
        {
            if (gameObject.CompareTag("FreezerInvalid"))
            {
                Debug.Log("FreezerInvalid Interaction Works");
            }
            if (gameObject.CompareTag("FreezerValid"))
            {
                Debug.Log("FreezerValid Interaction Works");

                PuzzleInteractable.currentRiddle = 2;
            }
        }


        if (PuzzleInteractable.currentRiddle == 2)
        {
            if (gameObject.CompareTag("ProduceInvalid"))
            {
                Debug.Log("ProduceInvalid Interaction Works");
            }
            if (gameObject.CompareTag("ProduceValid"))
            {
                Debug.Log("ProduceValid Interaction Works");

                PuzzleInteractable.currentRiddle = 3;
            }
        }


        if (PuzzleInteractable.currentRiddle == 3)
        {
            if (gameObject.CompareTag("ShelvesInvalid"))
            {
                Debug.Log("ShelvesInvalid Interaction Works");
            }
            if (gameObject.CompareTag("ShelvesValid"))
            {
                Debug.Log("ShelvesValid Interaction Works");

                PuzzleInteractable.currentRiddle = 4;
            }
        }


        if (PuzzleInteractable.currentRiddle == 4)
        {
            if (gameObject.CompareTag("RegistersInvalid"))
            {
                Debug.Log("RegistersInvalid Interaction Works");
            }
            if (gameObject.CompareTag("RegistersValid"))
            {
                Debug.Log("RegistersValid Interaction Works");

                PuzzleInteractable.currentRiddle = 5;
            }
        }


        if (PuzzleInteractable.currentRiddle == 5)
        {
            if (gameObject.CompareTag("BathroomInvalid"))
            {
                Debug.Log("BathroomInvalid Interaction Works");
            }
            if (gameObject.CompareTag("BathroomValid"))
            {
                Debug.Log("BathroomValid Interaction Works");

                PuzzleInteractable.currentRiddle = 6;
            }
        }


        if (PuzzleInteractable.currentRiddle == 6)
        {
            if (gameObject.CompareTag("DoorInteract"))
            {
                Debug.Log("DoorInteract Works");
                Destroy(gameObject);
                PuzzleInteractable.currentRiddle = 7;
            }
        }


        if (PuzzleInteractable.currentRiddle == 7)
        {
            if (gameObject.CompareTag("TalismanCollect"))
            {
                Debug.Log("TalismanCollect Interaction Works");
            }
        }

    }
}