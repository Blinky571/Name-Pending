using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagspot : MonoBehaviour, IInteractable
{
    public Powercell_Text powercell_Text;
    public string InteractionPrompt { get; }
    public GameObject replacement;
    public void FlagSpot(int flagsPlaced)
    {
        flagsPlaced++;
        replacement.SetActive(true);
        powercell_Text.FlagPlaced();
        Destroy(gameObject);
    }
    #region Unused
    public void ElevatorMove()
    {
    }
    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        return powerCellsAcquired;
    }
    #endregion
}
