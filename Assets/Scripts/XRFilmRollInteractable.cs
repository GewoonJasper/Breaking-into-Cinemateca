using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class XRFilmRollInteractable : XRGrabInteractable
{
    public XRDoorInteractable DoorInteractable;

    /// <summary>
    /// Go to victory scene if film roll is grabbed and door is interacted with
    /// </summary>
    void Update()
    {
        Debug.Log(isSelected + " " + DoorInteractable.isSelected);

        if (isSelected && DoorInteractable.isSelected)
            SceneManager.LoadScene("VictoryScene");
    }
}
