using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;

    public string InteractionPrompt { get; }

    public int SentenceNumber;

    public void ElevatorMove()
    {

            Debug.Log("Error");
            FindObjectOfType<DialogueManager>().StartDialouge(dialogue, SentenceNumber);


    }

    public void FlagSpot(int flagsPlaced)
    {
    }

    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        return powerCellsAcquired;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
