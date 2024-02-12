using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PianoInteract : MonoBehaviour
{
    public string puzzleSceneName = "PianoPuzzleScene"; // Change this to the actual name of your puzzle scene.
    public float interactionDistance = 3f; // Adjust the interaction distance based on your scene.

    public Text interactText; // Reference to the UI text element.

    private void Update()
    {
        // Check if the player is near the piano.
        bool isPlayerNear = IsPlayerNearPiano();

        // Show/hide the interact text based on player proximity.
        if (interactText != null)
        {
            interactText.gameObject.SetActive(isPlayerNear);
        }

        // If the player is near and presses 'E', load the puzzle scene.
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(puzzleSceneName);
        }
    }

    private bool IsPlayerNearPiano()
    {
        // Assuming the piano has a box collider.
        Collider pianoCollider = GetComponent<Collider>();

        if (pianoCollider != null)
        {
            // Check if the player is within the interaction distance.
            return Vector3.Distance(transform.position, Camera.main.transform.position) <= interactionDistance;
        }

        return false;
    }
}
