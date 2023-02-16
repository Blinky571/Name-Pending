using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCamera : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcam1; // Area 1

    [SerializeField]
    private CinemachineVirtualCamera vcam2; // Area 2

    private bool CurrentCamera = true;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter");
        if (CurrentCamera)
        {
            Debug.Log("Current Camera");
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }
        else
        {
            Debug.Log("non current camera");
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }
        CurrentCamera = !CurrentCamera;
    }

    void Update()
    {
        
    }

    /*private void SwitchPriority()
    {
        if (CurrentCamera)
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }

    }*/
}
