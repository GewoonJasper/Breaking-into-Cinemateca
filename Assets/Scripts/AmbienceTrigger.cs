using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AmbienceTrigger : MonoBehaviour
{
    public AudioMixerSnapshot Ambience;

    private void OnTriggerEnter() {
        Ambience.TransitionTo(2);
    }
    
}
