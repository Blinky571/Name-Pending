using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip JumpSound;
    public static AudioClip PowerSound;
    public static AudioClip DepositorSound;
    static AudioSource audioSrc;
    
    void Start()
    {
        JumpSound = Resources.Load<AudioClip>("Jetpack");
        PowerSound = Resources.Load<AudioClip>("Power Cell");
        DepositorSound = Resources.Load<AudioClip>("Insertion");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Jetpack":
                audioSrc.PlayOneShot(JumpSound);
                break;
        }

        switch (clip)
        {
            case "Power Cell":
                audioSrc.PlayOneShot(PowerSound);
                break;
        }

        switch (clip)
        {
            case "Insertion":
                audioSrc.PlayOneShot(DepositorSound);
                break;
        }
    }
}
