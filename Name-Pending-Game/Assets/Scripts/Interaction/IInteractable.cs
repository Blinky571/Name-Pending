using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string InteractionPrompt { get; }

    public int Interact(Interactor interactor, int powerCellsAcquired);

    public void ElevatorMove();

    public void FlagSpot(int flagsPlaced);

    public void popUp();

    public void popDown();
}
