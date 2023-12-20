using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        //TODO Add fade out
        SceneManager.LoadScene("IntroductionScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
