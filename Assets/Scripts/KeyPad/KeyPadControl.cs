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
    private TextMeshProUGUI _codeText;

    [SerializeField]
    [Tooltip("The door to unlock")]
    private GameObject _door;

    private string _currentCode = "";

    private bool _enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        //Check if the door is set
        if (_door == null)
        {
            Debug.LogError("Door is not set in the inspector!");
            this.enabled = false;
        }

        //Check if the code is set and can be parsed to an int
        //There is probably a better way to do this
        try
        {
            int code = int.Parse(_code);
        }
        catch
        {
            Debug.LogError("Code is not a numerical combination!");
            this.enabled = false;
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

    /// <summary>
    /// Adds a number to the current code
    /// </summary>
    /// <param name="number">The number to add</param>
    public void AddNumber(int number)
    {
        if (!_enabled) return;
        if (_currentCode.Length >= _code.Length) return;

        _currentCode += number;

        ShowCode();
    }

    /// <summary>
    /// Resets the current code
    /// </summary>
    public void Cancel()
    {
        _currentCode = "";
    }

    /// <summary>
    /// Checks if the current code is correct after the player pressed the check button
    /// </summary>
    public void CheckCode()
    {
        if (!_enabled) return;

        if (_currentCode.Equals(_code)) CodeCorrect();
        else CodeIncorrect();
    }

    /// <summary>
    /// Actions to perform if the code is correct
    /// </summary>
    private void CodeCorrect()
    {
        //Rotate the door 90 degrees over the y axis
        _door.transform.Rotate(0, 90, 0);
    }

    /// <summary>
    /// Actions to perform if the code is incorrect
    /// </summary>
    private void CodeIncorrect()
    {
        Cancel();
    }
}
