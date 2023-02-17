using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> _stations;
    [SerializeField] private int _CurrentStation;
    public string InteractionPrompt { get; }

    private void Update()
    {
        for (int i = 0; i < _stations.Count; i++)
        {
            if (this.gameObject == _stations[i])
            {
                _CurrentStation = i;
            }
        }
    }
    public void ElevatorMove()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = _stations[0].transform.position;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = _stations[1].transform.position;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = _stations[2].transform.position;
        }




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
