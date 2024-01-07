using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip Audio;
    
    private bool _hasTriggered;

    private void OnTriggerEnter() {
        if (_hasTriggered) return;
        _hasTriggered = true;
        AudioSource.clip = Audio;
        AudioSource.Play();
    }
}
