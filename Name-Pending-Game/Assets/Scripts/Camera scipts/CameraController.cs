using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPriority : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;
    private CinemachineVirtualCamera currentCamera;

    private void Start()
    {
        currentCamera = cameras[0];
    }

    private void Update()
    {
        float closestDistance = Mathf.Infinity;
        foreach (CinemachineVirtualCamera camera in cameras)
        {
            float distance = Vector3.Distance(camera.transform.position, transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                currentCamera = camera;
            }
        }

        currentCamera.Priority = 10;
        foreach (CinemachineVirtualCamera camera in cameras)
        {
            if (camera != currentCamera)
            {
                camera.Priority = 1;
            }
        }
    }
}