using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraCut : MonoBehaviour
{
    private CinemachineBrain brain;
    // Start is called before the first frame update
    void Awake()
    {
        brain = FindObjectOfType<CinemachineBrain>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        brain.m_DefaultBlend.m_Time = 1;
    }
}
