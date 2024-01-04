using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is made specifically for the Introduction scene
/// Do not use it in other scenes
/// </summary>
public class Introduction : MonoBehaviour
{
    public FadeScreen FadeScreen;

    public AudioMixerSnapshot NoAmbience;
    public AudioMixerSnapshot Ambience;

    public AudioSource DriverVoice;
    private bool _startedPlaying = false;

    private bool _stoppedPlaying = false;

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
        switch (_startedPlaying)
        {
            case false when !FadeScreen.HasFaded():
                return;
            case false:
                _startedPlaying = true;
                DriverVoice.Play();
                break;
        }

        if (DriverVoice.isPlaying) return;

        if (!_stoppedPlaying)
        {
            FadeScreen.FadeOut();
            NoAmbience.TransitionTo(4);
        }

        _stoppedPlaying = true;
        
        if (FadeScreen.HasFaded())
            SceneManager.LoadScene("CinematecaScene");
    }
}
