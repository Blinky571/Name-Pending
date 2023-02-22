using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Elevator : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _depositor;
    [SerializeField] private GameObject _player;
    private CinemachineBrain brain;
    public string InteractionPrompt { get; }   
    private void Awake()
    {
        _depositor = GameObject.Find("Depositor");
        _player = GameObject.FindGameObjectWithTag("Player");
        brain = FindObjectOfType<CinemachineBrain>();
    }
    public void ElevatorMove()
    {
        brain.m_DefaultBlend.m_Time = 0;
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
