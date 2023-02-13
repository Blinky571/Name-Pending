using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depositor : MonoBehaviour, IInteractable
{
    public string InteractionPrompt { get; }

    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        if (powerCellsAcquired > 0)
        {
            powerCellsAcquired--;
            DoTheThing();
        }
        else
        {
        }

        return powerCellsAcquired;
    }

    public void ElevatorMove()
    {
    }

    public void FlagSpot(int flagsPlaced)
    {
        throw new System.NotImplementedException();
    }

    private void DoTheThing()
    {

    }
}
