using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depositor : MonoBehaviour, IInteractable
{
    public Powercell_Text powercell_Text;
    public string InteractionPrompt { get; }
    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        if (powerCellsAcquired > 0)
        {
            powerCellsAcquired--;
            powercell_Text.HoldingPowercell(powerCellsAcquired);
            powercell_Text.GatheredPowercell();
        }
        return powerCellsAcquired;
    }
    public void ElevatorMove()
    {
    }
    public void FlagSpot(int flagsPlaced)
    {
    }
}
