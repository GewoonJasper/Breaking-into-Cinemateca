using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public AudioSource Audio;
    public Animator animator;

    private bool _fadeInFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (!_fadeInFinished || Audio.isPlaying) return;
        
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeInComplete()
    {
        Audio.Play();
        _fadeInFinished = true;
    }

    public void OnFadeOutComplete()
    {
        SceneManager.LoadScene("CinematecaScene");
    }
}
