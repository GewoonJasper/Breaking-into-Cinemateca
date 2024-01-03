using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public FadeScreen FadeScreen;
    
    public void RestartButton()
    {
        FadeScreen.FadeOut();
        
        //while (!FadeScreen.HasFaded()) { }
        SceneManager.LoadScene("CinematecaScene");
    }

    public void MainMenuButton()
    {
        FadeScreen.FadeOut();

        //while (!FadeScreen.HasFaded()) { }
        SceneManager.LoadScene("MainMenuScene");
    }
}
