using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audio;
    private bool hasTriggered;


    private void OnTriggerEnter()
    {
        if (hasTriggered) return;
        hasTriggered = true;
        audioSource.clip = audio;
        audioSource.Play();
    }
}
