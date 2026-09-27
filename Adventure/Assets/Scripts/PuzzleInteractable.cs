using UnityEngine;

//PF
//Puzzle Interactions

public class PuzzleInteractable : BaseInteractable
{
    public int currentRiddle = 1;

    public override void Interact()
    {
        if(currentRiddle == 1)
        {
            if (gameObject.CompareTag("FreezerInvalid"))
            {
                Debug.Log("FreezerInvalid Interaction Works");
            }
            if (gameObject.CompareTag("FreezerValid"))
            {
                Debug.Log("FreezerValid Interaction Works");
            }
        }


        if (currentRiddle == 1)
        {
            if (gameObject.CompareTag("ProduceInvalid"))
            {
                Debug.Log("ProduceInvalid Interaction Works");
            }
            if (gameObject.CompareTag("ProduceValid"))
            {
                Debug.Log("ProduceValid Interaction Works");
            }
        }


        if (currentRiddle == 1)
        {
            if (gameObject.CompareTag("ShelvesInvalid"))
            {
                Debug.Log("ShelvesInvalid Interaction Works");
            }
            if (gameObject.CompareTag("ShelvesValid"))
            {
                Debug.Log("ShelvesValid Interaction Works");
            }
        }


        if (currentRiddle == 1)
        {
            if (gameObject.CompareTag("RegistersInvalid"))
            {
                Debug.Log("RegistersInvalid Interaction Works");
            }
            if (gameObject.CompareTag("RegistersValid"))
            {
                Debug.Log("RegistersValid Interaction Works");
            }
        }

    }
}