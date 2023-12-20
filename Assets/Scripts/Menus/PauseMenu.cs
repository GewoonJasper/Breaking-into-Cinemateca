using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private bool _isPaused;

    // Start is called before the first frame update
    void Start()
    {
        //enabled = _isPaused;
        //Time.timeScale = _isPaused ? 0 : 1;

        //TogglePauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!_isPaused) return;

        Vector3 vHeadPos = _camera.transform.position;
        Vector3 vGazeDir = _camera.transform.forward;
        transform.position = (vHeadPos + vGazeDir * 3.0f) + new Vector3(0.0f, -.40f, 0.0f);
        Vector3 vRot = _camera.transform.eulerAngles; vRot.z = 0;
        transform.eulerAngles = vRot;
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed) TogglePauseMenu();
    }

    public void TogglePauseMenu()
    {
        Debug.Log("Test");

        _isPaused = !_isPaused;
        enabled = _isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
    }

    private void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
