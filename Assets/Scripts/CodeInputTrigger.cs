using UnityEngine;

public class CodeInputTrigger : MonoBehaviour
{
    public GameObject codeInputCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateCodeInputCanvas();
        }
    }

    private void ActivateCodeInputCanvas()
    {
        // Activate the canvas for code input.
        codeInputCanvas.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DeActivateCodeInputCanvas();
        }
    }

    private void DeActivateCodeInputCanvas()
    {
        // Activate the canvas for code input.
        codeInputCanvas.SetActive(false);
    }

}