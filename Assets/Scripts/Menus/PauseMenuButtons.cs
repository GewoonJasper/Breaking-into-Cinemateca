using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public FadeScreen FadeScreen;
    private string _sceneName = "";

    void Update()
    {
        if (_sceneName == "") return;

        if (FadeScreen.HasFaded())
            SceneManager.LoadScene(_sceneName);
    }

    public void RestartButton()
    {
        FadeScreen.FadeOut();
        _sceneName = "CinematecaScene";
    }

    public void MainMenuButton()
    {
        FadeScreen.FadeOut();
        _sceneName = "MainMenuScene";
    }
}
