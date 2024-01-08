using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public FadeScreen FadeScreen;
    private bool _startButtonClicked;

    void Update()
    {
        if (!_startButtonClicked) return;

        if (FadeScreen.HasFaded())
            SceneManager.LoadScene("IntroductionScene");
    }
    public void StartGame()
    {
        FadeScreen.FadeOut();
        _startButtonClicked = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
