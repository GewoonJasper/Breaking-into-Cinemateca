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
        _isPaused = !_isPaused;
        TogglePauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPaused) return;

        Vector3 headPos = _camera.transform.position;
        Vector3 gazeDir = _camera.transform.forward;

        transform.position = (headPos + gazeDir * 3.0f) + new Vector3(0.0f, -.40f, 0.0f);
        transform.position = new Vector3(transform.position.x, headPos.y, transform.position.z);

        Vector3 vRot = _camera.transform.eulerAngles; vRot.z = 0;
        transform.eulerAngles = vRot;
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed) TogglePauseMenu();
    }

    private void TogglePauseMenu()
    {
        _isPaused = !_isPaused;
        gameObject.SetActive(_isPaused);
        Time.timeScale = _isPaused ? 0 : 1;
    }
}
