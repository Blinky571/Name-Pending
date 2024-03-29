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

        FlagsPlaced.text = _flagsPlaced.ToString();
        Holding.text = _currentAmountOnSteven.ToString() + "/3";
        Gathered.text = _amountGatheredToShip.ToString() + "/" + _amountToWin.ToString();
        if (_amountGatheredToShip >= _amountToWin)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    public void GatheredPowercell(int powerCellsDeposited)
    {
        _amountGatheredToShip += powerCellsDeposited;
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
