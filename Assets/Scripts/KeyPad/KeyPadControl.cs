using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPadControl : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The digit code to unlock the door")]
    private string _code = "0000"; // A string because int would not add leading zero

    [SerializeField]
    [Tooltip("The text to display the code")]
    private TextMeshProUGUI _codeText;

    [SerializeField]
    [Tooltip("The door to unlock")]
    private List<GameObject> _doors = new List<GameObject>();

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField] 
    private AudioSource _earpieceAudioSource;

    [SerializeField]
    private AudioClip _earpieceAudioClip;

    public AudioClip CorrectSound;
    public AudioClip IncorrectSound;
    public AudioClip ButtonSound;

    private string _currentCode = "";
    private bool _unlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        //Check if the door is set
        if (_doors.Count == 0)
        {
            Debug.LogError("Door is not set in the inspector!");
            gameObject.SetActive(false);
        }

        //Check if the code is set and can be parsed to an int
        //There is probably a better way to do this
        try
        {
            int.Parse(_code);
        }
        catch
        {
            Debug.LogError("Code is not a numerical combination!");
            gameObject.SetActive(false);
        }

        ShowCode();
    }

    private void ShowCode()
    {
        _codeText.text = _currentCode;
        for (int i = _currentCode.Length; i < _code.Length; i++)
        {
            _codeText.text += "x";
        }
    }

    private void PlaySound(AudioClip sound)
    {
        _audioSource.clip = sound;
        _audioSource.Play();
    }

    /// <summary>
    /// Adds a number to the current code
    /// </summary>
    /// <param name="number">The number to add</param>
    public void AddNumber(int number)
    {
        if (_unlocked || _currentCode.Length >= _code.Length) return;

        PlaySound(ButtonSound);
        _currentCode += number;

        ShowCode();
    }

    /// <summary>
    /// Resets the current code
    /// </summary>
    public void Cancel()
    {
        if (_unlocked) return;

        PlaySound(ButtonSound);

        _currentCode = "";
        ShowCode();
    }

    /// <summary>
    /// Checks if the current code is correct after the player pressed the check button
    /// </summary>
    public void CheckCode()
    {
        if (_unlocked) return;

        PlaySound(ButtonSound);

        if (_currentCode.Equals(_code)) CodeCorrect();
        else CodeIncorrect();
    }

    /// <summary>
    /// Actions to perform if the code is correct
    /// </summary>
    private void CodeCorrect()
    {
        PlaySound(CorrectSound);
        _earpieceAudioSource.clip = _earpieceAudioClip;
        _earpieceAudioSource.Play();

        //Play door open animation
        //Later maybe change this to a grabbable door instead of animation
        foreach (var door in _doors)
            door.GetComponent<Animator>().SetTrigger("DoorUnlocked");

        _unlocked = true;
    }

    /// <summary>
    /// Actions to perform if the code is incorrect
    /// </summary>
    private void CodeIncorrect()
    {
        PlaySound(IncorrectSound);

        _currentCode = "";
        ShowCode();
    }
}
