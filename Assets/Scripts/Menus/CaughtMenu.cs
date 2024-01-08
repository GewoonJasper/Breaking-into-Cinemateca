using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CaughtMenu : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private List<XRRayInteractor> _rayInteractors = new List<XRRayInteractor>();

    private bool _isCaught = false;

    // Update is called once per frame
    void Update()
    {
        if (!_isCaught) return;

        Vector3 headPos = _camera.transform.position;
        Vector3 gazeDir = _camera.transform.forward;

        transform.position = (headPos + gazeDir * 3.0f) + new Vector3(-0.5f, -.40f, 0.0f);
        transform.position = new Vector3(transform.position.x, headPos.y, transform.position.z);

        Vector3 vRot = _camera.transform.eulerAngles; vRot.z = 0;
        transform.eulerAngles = vRot;
    }

    public void PlayerCaught()
    {
        if (_isCaught) return;

        //Switch pause state
        _isCaught = true;

        //Show/hide the pause menu
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);

        //(Un-)pause game
        Time.timeScale = 0;
        
        if (_rayInteractors.Count == 0) return;
        foreach (var xrRayInteractor in _rayInteractors)
            xrRayInteractor.enabled = true;
    }
}
