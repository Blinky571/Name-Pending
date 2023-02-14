using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell : MonoBehaviour, IInteractable
{
    public Powercell_Text powercell_Text;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public ParticleSystem CollectParticle;

    public void ElevatorMove()
    {
    }

    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        CollectParticle.Play();

        if (powerCellsAcquired < 3)
        {
            powerCellsAcquired++;
            powercell_Text.HoldingPowercell(powerCellsAcquired);
        }
        return powerCellsAcquired;
    }

    public void FlagSpot(int flagsPlaced)
    {
    }

}
