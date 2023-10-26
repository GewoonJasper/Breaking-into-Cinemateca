using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for fading in and out of scenes
/// IMPORTANT: Only place this script in the Fader GameObject
/// </summary>
public class Fader : MonoBehaviour
{
    private static Animator _animator;
    public string NextScene;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public static void FadeOut()
    {
        _animator.SetTrigger("FadeOut");
    }


    public void OnFadeOutComplete()
    {
        SceneManager.LoadScene(NextScene);
    }
}
