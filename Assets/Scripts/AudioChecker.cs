using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Checks if the given audio has finished playing and then calls the Fader scene
/// IMPORTANT: This script only has one functionality. If we want to use it with more possibilities it should be refactored
/// </summary>
public class AudioChecker : MonoBehaviour
{
    public AudioSource AudioToCheck;

    // Update is called once per frame
    void Update()
    {
        if (AudioToCheck.isPlaying) return;

        Fader.FadeOut();
    }
}
