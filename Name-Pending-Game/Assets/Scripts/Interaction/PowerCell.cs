using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell : MonoBehaviour, IInteractable
{
    public GameObject popUpPromt;
    public Powercell_Text powercell_Text;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public ParticleSystem CollectParticle;

    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        if (powerCellsAcquired < 3)
        {
            powerCellsAcquired++;
            Instantiate(CollectParticle, transform.position, Quaternion.identity);
            powercell_Text.HoldingPowercell(powerCellsAcquired);
            Destroy(gameObject);
        }
        return powerCellsAcquired;
    }
    private IEnumerator StartPulsing()
    {
        for (float i = 0; i <= 1; i += 0.1f)
        {
            transform.localScale = new Vector3(
            (Mathf.Lerp(popUpPromt.transform.localScale.x, popUpPromt.transform.localScale.x - 0.025f, Mathf.SmoothStep(0f, 1f, i))),
            (Mathf.Lerp(popUpPromt.transform.localScale.y, popUpPromt.transform.localScale.y - 0.025f, Mathf.SmoothStep(0f, 1f, i))),
            (Mathf.Lerp(popUpPromt.transform.localScale.z, popUpPromt.transform.localScale.z - 0.025f, Mathf.SmoothStep(0f, 1f, i))));
            yield return new WaitForSeconds(0.015f);
        }
        for (float i = 0; i <= 1; i += 0.1f)
        {
            transform.localScale = new Vector3(
            (Mathf.Lerp(popUpPromt.transform.localScale.x, popUpPromt.transform.localScale.x + 0.025f, Mathf.SmoothStep(0f, 1f, i))),
            (Mathf.Lerp(popUpPromt.transform.localScale.y, popUpPromt.transform.localScale.y + 0.025f, Mathf.SmoothStep(0f, 1f, i))),
            (Mathf.Lerp(popUpPromt.transform.localScale.z, popUpPromt.transform.localScale.z + 0.025f, Mathf.SmoothStep(0f, 1f, i))));
             yield return new WaitForSeconds(0.015f);
        }
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
