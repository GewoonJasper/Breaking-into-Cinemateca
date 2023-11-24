using UnityEngine;

public class AlarmFPS : MonoBehaviour
{
    public GameObject alarmLight;
    public AudioClip alarmSound;
    public float timeLockDuration = 10f;

    private bool isGrabbed = false;
    private float timeLockTimer;

    private void Update()
    {
        if (isGrabbed)
        {
            // Check if the time lock is active
            if (timeLockTimer > 0)
            {
                timeLockTimer -= Time.deltaTime;
            }
            else
            {
                // Time lock is over, reset the alarm
                ResetAlarm();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isGrabbed)
        {
            // Player grabbed the film roll
            TriggerAlarm();
        }
    }

    private void TriggerAlarm()
    {
        // Activate red light
        alarmLight.SetActive(true);

        // Play alarm sound
        AudioSource.PlayClipAtPoint(alarmSound, transform.position);

        // Set the time lock
        timeLockTimer = timeLockDuration;

        // Set the flag to indicate the film roll is grabbed
        isGrabbed = true;
    }

    private void ResetAlarm()
    {
        // Deactivate red light
        alarmLight.SetActive(false);

        // Reset flag and timer
        isGrabbed = false;
        timeLockTimer = 0f;
    }
}