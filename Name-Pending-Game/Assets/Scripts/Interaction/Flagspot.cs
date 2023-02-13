using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagspot : MonoBehaviour, IInteractable
{
    public string InteractionPrompt { get; }
    public GameObject replacement;

    public void ElevatorMove()
    {
        throw new System.NotImplementedException();
    }

    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        throw new System.NotImplementedException();
    }

    public void FlagSpot(int flagsPlaced)
    {
        Instantiate(replacement, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
