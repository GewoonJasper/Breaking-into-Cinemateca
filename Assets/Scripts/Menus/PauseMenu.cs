using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private List<XRRayInteractor> _rayInteractors = new List<XRRayInteractor>();

    [SerializeField]
    private InputActionProperty _pauseButton;
    
    private bool _isPaused = true;

    private void Start()
    {
        //Hide the pause menu (it starts on true and toggles to off by calling this function)
        TogglePauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (_pauseButton.action.triggered) TogglePauseMenu();

        if (!_isPaused) return;

        Vector3 headPos = _camera.transform.position;
        Vector3 gazeDir = _camera.transform.forward;

        transform.position = (headPos + gazeDir * 3.0f) + new Vector3(-0.5f, -.40f, 0.0f);
        transform.position = new Vector3(transform.position.x, headPos.y, transform.position.z);

        Vector3 vRot = _camera.transform.eulerAngles; vRot.z = 0;
        transform.eulerAngles = vRot;
    }

    private void TogglePauseMenu()
    {
        //Switch pause state
        _isPaused = !_isPaused;

        //Show/hide the pause menu
        foreach (Transform child in transform)
            child.gameObject.SetActive(_isPaused);

        //(Un-)pause game
        Time.timeScale = _isPaused ? 0 : 1;
        
        if (_rayInteractors.Count == 0) return;
        foreach (var xrRayInteractor in _rayInteractors)
            xrRayInteractor.enabled = _isPaused;
    }
}
