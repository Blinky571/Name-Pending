using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _depositor;
    [SerializeField] private GameObject _player;
    public string InteractionPrompt { get; }   
    private void Awake()
    {
        _depositor = GameObject.Find("Depositor");
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    public void ElevatorMove()
    {
        _player.transform.position = _depositor.transform.position;   
    }
    #region Unused
    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        return powerCellsAcquired;
    }
    public void FlagSpot(int FlagsPlaced)
    {
    }
    #endregion
}
