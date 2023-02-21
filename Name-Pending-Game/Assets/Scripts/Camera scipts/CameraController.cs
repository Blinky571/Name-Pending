using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;
    [SerializeField] private CinemachineVirtualCamera thisCamera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].Priority = 0;
        }
        thisCamera.Priority = 1;
    }
}