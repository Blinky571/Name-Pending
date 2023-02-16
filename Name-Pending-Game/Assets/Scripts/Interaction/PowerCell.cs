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


    public void ElevatorMove()
    {
    }

    public int Interact(Interactor interactor, int powerCellsAcquired)
    {

        if (powerCellsAcquired < 3)
        {
            powerCellsAcquired++;
            CollectParticle.Play();
            powercell_Text.HoldingPowercell(powerCellsAcquired);
            Destroy(gameObject);
        }
        return powerCellsAcquired;
    }

    public void FlagSpot(int flagsPlaced)
    {
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

    public void popUp()
    {
        popUpPromt.SetActive(true);
        StartCoroutine("StartPulsing");
    }

    public void popDown()
    {
        popUpPromt.SetActive(false);
        StopCoroutine("StartPulsing");
    }
}
