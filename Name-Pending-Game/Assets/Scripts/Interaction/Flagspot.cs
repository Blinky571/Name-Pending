using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagspot : MonoBehaviour, IInteractable
{
    public Powercell_Text powercell_Text;

    public string InteractionPrompt { get; }
    public GameObject replacement;

    public void ElevatorMove()
    {
    }

    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        return powerCellsAcquired;
    }

    public void FlagSpot(int flagsPlaced)
    {
        flagsPlaced++;
        Instantiate(replacement, transform.position, transform.rotation);
        powercell_Text.FlagPlaced();
        Destroy(gameObject);
    }

    public void popUp()
    {
        throw new System.NotImplementedException();
    }
}
