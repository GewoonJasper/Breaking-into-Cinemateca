using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AmbienceTrigger : MonoBehaviour
{
    public AudioMixerSnapshot Ambience;

    private void OnTriggerEnter() {
        ChangeAmbience();
    }

    //Extra method for accessibility in chase state
    public void ChangeAmbience()
    {
        Ambience.TransitionTo(2);
    }
}
