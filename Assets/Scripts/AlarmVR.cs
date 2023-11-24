using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AlarmVR : XRGrabInteractable
{
    public GameObject alarmLight;
    public AudioClip alarmSound;
    public float timeLockDuration = 10f;

    private bool isGrabbed = false;
    private float timeLockTimer;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (!isGrabbed)
        {
            TriggerAlarm();
        }
    }

    private void Update()
    {
        if (isGrabbed)
        {
            if (timeLockTimer > 0)
            {
                timeLockTimer -= Time.deltaTime;
            }
            else
            {
                ResetAlarm();
            }
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