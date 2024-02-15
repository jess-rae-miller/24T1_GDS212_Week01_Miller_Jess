using UnityEngine;

public class ToggleAudioOnKeyPress : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    private bool isAudioPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInCollider())
        {
            if (isAudioPlaying)
            {
                audioSource.Stop();
            }
            else
            {
                audioSource.Play();
            }

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
