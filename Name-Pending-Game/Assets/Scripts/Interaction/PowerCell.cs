using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell : MonoBehaviour, IInteractable
{
    public Powercell_Text powercell_Text;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public void ElevatorMove()
    {
    }

    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        if (powerCellsAcquired < 3)
        {
            powerCellsAcquired++;
            powercell_Text.HoldingPowercell(powerCellsAcquired);
            Destroy(gameObject);
        }
        return powerCellsAcquired;
    }

    public void FlagSpot(int flagsPlaced)
    {
    }

}
