using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Powercell_Text : MonoBehaviour
{
    private int _currentAmountOnSteven;
    private int _amountGatheredToShip;
    private int _flagsPlaced;
    public TextMeshProUGUI Gathered;
    public TextMeshProUGUI Holding;
    public TextMeshProUGUI FlagsPlaced;
    public int _amountToWin;
    private void Update()
    {
        FlagsPlaced.text = FlagsPlaced.ToString() + " Flagged";
        Holding.text = "Holding " + _currentAmountOnSteven.ToString() + "/3";
        Gathered.text = _amountGatheredToShip.ToString() + "/" + _amountToWin.ToString() + " Deposited";
        if (_amountGatheredToShip >= _amountToWin)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    public void GatheredPowercell()
    {
        _amountGatheredToShip++;
    }
    public void HoldingPowercell(int powerCellsGathered)
    {
        _currentAmountOnSteven = powerCellsGathered;        
    }

    public void FlagPlaced()
    {
        _flagsPlaced++;
    }
}
