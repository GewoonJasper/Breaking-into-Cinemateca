using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class XRFilmRollInteractable : XRGrabInteractable
{
    public XRGrabInteractable DoorInteractable;

    /// <summary>
    /// Go to victory scene if film roll is grabbed and door is interacted with
    /// </summary>
    void Update()
    {
        if (isSelected && DoorInteractable.isSelected)
            SceneManager.LoadScene("VictoryScene");
    }
}
