using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public GameObject popUpPromt;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    private readonly Collider2D[] _collidders = new Collider2D[3];
    [SerializeField] private int _numFound;
    [SerializeField] private int powerCellsAcquired;
    [SerializeField] private int flagsPlaced;
    private void Update()
    {
        _numFound = Physics2D.OverlapCircleNonAlloc(_interactionPoint.position, _interactionPointRadius, _collidders, (int)_interactableMask);
        if (_numFound > 0)
        {
            var interactable = _collidders[0].GetComponent<IInteractable>();
            popUpPromt.SetActive(true);
            if (interactable != null && Input.GetButtonDown("Interact"))
            {
                powerCellsAcquired = interactable.Interact(this, powerCellsAcquired);
                interactable.ElevatorMove();
                interactable.FlagSpot(flagsPlaced);
            }
        }
        else
        {
            popUpPromt.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
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
}

