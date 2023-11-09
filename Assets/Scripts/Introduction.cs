using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// This script is made specifically for the Introduction scene
/// Do not use it in other scenes
/// </summary>
public class Introduction : MonoBehaviour
{
    public AudioMixerSnapshot NoAmbience;
    public AudioMixerSnapshot Ambience;

    public AudioSource DriverVoice;

    /// <summary>
    /// Make van sound fade in, as to not suddenly have the sound in your ears
    /// </summary>
    void Start()
    {
        Ambience.TransitionTo(1);
    }

    /// <summary>
    /// Waits until the driver is done talking
    /// Then fades out the van sound and loads the next scene
    /// </summary>
    void Update()
    {
        if (DriverVoice.isPlaying) return;

        NoAmbience.TransitionTo(4);
        Fader.FadeOut();
    }
}
