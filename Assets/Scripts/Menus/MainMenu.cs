using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public FadeScreen FadeScreen;

    public void StartGame()
    {
        FadeScreen.FadeOut();
        
        //while (!FadeScreen.HasFaded()) { }
        SceneManager.LoadScene("IntroductionScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
