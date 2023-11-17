﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    [SerializeField] private Text Ans;
    [SerializeField] private Animator DoorOpening;

    private string Answer = "1388";

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Execute()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "YES";
            DoorOpening.SetBool("Open", true);
        }
        else
        {
            Ans.text = "NO";
        }

    }

}
