using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;

    public string InteractionPrompt { get; }

    public void ElevatorMove()
    {
        FindObjectOfType<DialogueManager>().StartDialouge(dialogue);
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
