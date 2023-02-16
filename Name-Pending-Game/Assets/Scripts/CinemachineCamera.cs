using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineCamera : MonoBehaviour
{
    [SerializeField] //felt til at indsætte kamera
    private CinemachineVirtualCamera vcam1; // Area 1
    [SerializeField] //felt til at indsætte kamera
    private CinemachineVirtualCamera vcam2; // Area 2
    private void OnTriggerEnter2D(Collider2D other) //aktivere koden når man går ind i triggeren
    {
        if (vcam1.Priority > vcam2.Priority) //tjekker om vcam1 priority er højere end vcam2
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }
    }
}