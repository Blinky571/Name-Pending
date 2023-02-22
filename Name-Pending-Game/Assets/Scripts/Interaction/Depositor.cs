using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depositor : MonoBehaviour, IInteractable
{
    public Powercell_Text powercell_Text;
    public string InteractionPrompt { get; }

    public ParticleSystem particle;

    public Dialogue dialogue;




    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        if (powerCellsAcquired > 0)
        {
            particle.Play();
            powercell_Text.GatheredPowercell(powerCellsAcquired);
            powerCellsAcquired = 0;
            powercell_Text.HoldingPowercell(powerCellsAcquired);
            SoundManagerScript.PlaySound("Insertion");
        }
        else
        {
            FindObjectOfType<DialogueManager>().ShipDialogue(dialogue);
        }
        return powerCellsAcquired;
    }

    #region Unused
    public void ElevatorMove()
    {
    }
    public void FlagSpot(int flagsPlaced)
    {
    }
    #endregion
}
