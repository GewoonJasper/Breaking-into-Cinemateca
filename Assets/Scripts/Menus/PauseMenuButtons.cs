using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public FadeScreen FadeScreen;
    private string _sceneName = "";
    private bool _buttonClicked = false;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _restartAudio;

    private bool _audioPlayed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) RestartButton();

        if (_sceneName == "") return;

        if (FadeScreen.HasFaded())
        {
            if (!_audioPlayed && _sceneName == "CinematecaScene")
            {
                _audioSource.Play();
                _audioPlayed = true;
            }

            if (_audioSource == null || !_audioSource.isPlaying) SceneManager.LoadScene(_sceneName);
        }
    }

    public void RestartButton()
    {
        if (_buttonClicked) return;
        _buttonClicked = true;

        FadeScreen.FadeOut();
        _sceneName = "CinematecaScene";
        _audioSource.clip = _restartAudio;
    }

    public void MainMenuButton()
    {
        if (_buttonClicked) return;
        _buttonClicked = true;

        FadeScreen.FadeOut();
        _sceneName = "MainMenuScene";
    }
}
