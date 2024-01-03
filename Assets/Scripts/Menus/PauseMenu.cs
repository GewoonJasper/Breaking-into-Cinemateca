using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private List<XRRayInteractor> _rayInteractors = new List<XRRayInteractor>();

    [SerializeField] 
    private ContinuousMoveProviderBase _movement;
    
    private bool _isPaused = false;

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
        //Switch pause state
        _isPaused = !_isPaused;

        //(De-)acivate the pause menu
        gameObject.SetActive(_isPaused);

        //(Un-)pause game
        Time.timeScale = _isPaused ? 0 : 1;

        //Disable/Enable movement and ray interactor
        //if (_movement) _movement.enabled = !_isPaused;

        foreach (var xrRayInteractor in _rayInteractors)
            xrRayInteractor.enabled = _isPaused;
    }
}
