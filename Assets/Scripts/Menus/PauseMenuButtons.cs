using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public FadeScreen FadeScreen;
    private string _sceneName = "";
    private bool _buttonClicked = false;

    void Update()
    {
        if (_sceneName == "") return;
        
        if (FadeScreen.HasFaded())
            SceneManager.LoadScene(_sceneName);
    }

    public void RestartButton()
    {
        if (_buttonClicked) return;
        _buttonClicked = true;

        FadeScreen.FadeOut();
        _sceneName = "CinematecaScene";
    }

    public void MainMenuButton()
    {
        if (_buttonClicked) return;
        _buttonClicked = true;

        FadeScreen.FadeOut();
        _sceneName = "MainMenuScene";
    }
}
