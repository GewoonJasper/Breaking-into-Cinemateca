using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneChange : MonoBehaviour
{
    public AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        Audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Audio.isPlaying) SceneManager.LoadScene("CinematecaScene");
    }
}
