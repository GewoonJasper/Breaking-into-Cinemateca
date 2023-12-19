using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    //public float CameraDistance = 3.0F;
    //public float smoothTime = 0.3F;
    //private Vector3 velocity = Vector3.zero;
    //private Transform target;

    private bool _isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        //TogglePauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 targetPosition = _camera.transform.TransformPoint(new Vector3(0, 0, CameraDistance));
       
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //var lookAtPos = new Vector3(_camera.transform.position.x, transform.position.y, _camera.transform.position.z);
        //transform.LookAt(lookAtPos);

        Vector3 vHeadPos = _camera.transform.position;
        Vector3 vGazeDir = _camera.transform.forward;
        transform.position = (vHeadPos + vGazeDir * 3.0f) + new Vector3(0.0f, -.40f, 0.0f);
        Vector3 vRot = _camera.transform.eulerAngles; vRot.z = 0;
        transform.eulerAngles = vRot;
    }

    public void TogglePauseMenu()
    {
        _isPaused = !_isPaused;
        enabled = _isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
    }

    private void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
