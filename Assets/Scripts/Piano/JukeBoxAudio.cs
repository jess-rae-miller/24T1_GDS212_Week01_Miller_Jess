using UnityEngine;

public class ToggleAudioOnKeyPress : MonoBehaviour
{
    public AudioClip audioClip; // Assign your audio clip in the Unity Editor
    private AudioSource audioSource;
    private bool isAudioPlaying = false;

    void Start()
    {
        // Create an AudioSource component if not already attached
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the audio clip to the AudioSource component
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // Check if the player is within the collider and presses the "E" key
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInCollider())
        {
            // Toggle between playing and stopping the audio
            if (isAudioPlaying)
            {
                audioSource.Stop();
            }
            else
            {
                audioSource.Play();
            }

            // Update the state of audio playback
            isAudioPlaying = !isAudioPlaying;
        }
    }

    bool IsPlayerInCollider()
    {
        Collider collider = GetComponent<Collider>();

        if (collider != null)
        {

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                return collider.bounds.Contains(player.transform.position);
            }
        }

        return false;
    }
}
