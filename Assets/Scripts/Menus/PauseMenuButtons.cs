using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void RestartButton()
    {
        SceneManager.LoadScene("CinematecaScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
