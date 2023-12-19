using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class StartGameButton : XRSimpleInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args) {
        //TODO Add fade out
        SceneManager.LoadScene("IntroductionScene");
    }
}
