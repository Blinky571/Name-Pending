using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYS : MonoBehaviour
{
    private float timeRemaining;
    private bool timerIsRunning = false;


    private void Start()
    {
        timeRemaining = 1f;
    }
    private void Update()
    {
        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
                timerIsRunning = false;
            }
        }
    }

}

