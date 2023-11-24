using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilmRollController : MonoBehaviour
{
    private bool isPlayerNear = false;
    private bool hasFilmRoll = false;

    [SerializeField] private Collider mainDoorTrigger;
    [SerializeField] private Canvas victoryCanvas;

    private void Start()
    {
        // Find the main door trigger zone by its tag at runtime.
        GameObject mainDoor = GameObject.FindGameObjectWithTag("MainDoor");
        if (mainDoor != null)
        {
            mainDoorTrigger = mainDoor.GetComponent<Collider>();
            Debug.Log("Main door trigger found and assigned!");
        }
        else
        {
            Debug.LogError("Main door not found or does not have a Collider component!");
        }

        // Leave the victory canvas disabled at the start.
        if (victoryCanvas != null)
        {
            victoryCanvas.enabled = false;
        }
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!hasFilmRoll)
            {
                GrabFilmRoll();
            }
            else
            {
                TryExitMainDoor();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with the door! " + other.name);

        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void GrabFilmRoll()
    {
        // Disable the renderer and collider of the film roll.
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Set the flag indicating that the player has the film roll.
        hasFilmRoll = true;

        Debug.Log("Film roll grabbed!");
    }

    private void TryExitMainDoor()
    {
        // Debug log.
        Debug.Log("Player successfully exited with the film roll!");

        // Check if the player is in the trigger zone of the main door.
        if (isPlayerAtMainDoor())
        {
            Debug.Log("Player is at the main door trigger zone.");

            // Enable the victory canvas.
            if (victoryCanvas != null)
            {
                victoryCanvas.enabled = true;
            }
            
        }
        else
        {
            // Inform the player that they can't exit without the film roll.
            Debug.Log("You need the film roll to exit through the main door!");
        }
    }

    private bool isPlayerAtMainDoor()
    {
        if (mainDoorTrigger == null)
        {
            Debug.LogError("Main door trigger not found!");
            return false;
        }

        // Check if the player is within the trigger zone of the main door.
        return mainDoorTrigger.bounds.Intersects(GetComponent<Collider>().bounds);
    }
}
