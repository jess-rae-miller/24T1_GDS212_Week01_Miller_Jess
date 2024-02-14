using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 playerPosition;
    [SerializeField] private GameObject wallToDisable;

    private void Awake()
    {
        // Check if any other instances of this object exist
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            // If another object exists, destroy this one
            Destroy(gameObject);
        }
        else
        {
            // Else, make this object persistent
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // Check if the wall should be disabled
        if (PlayerPrefs.GetInt("DisableWall", 0) == 1)
        {
            SceneController.DisableWall(wallToDisable);
            PlayerPrefs.SetInt("DisableWall", 0);  // Reset the PlayerPrefs flag
        }
    }
    void OnDestroy()
    {
        // It's important to unsubscribe when the object is destroyed to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!player && FindAnyObjectByType<PlayerMovement>())
        {
            player = FindAnyObjectByType<PlayerMovement>().gameObject;
        }

        // If player is found and has a previous position, teleport them
        if (player && playerPosition != Vector3.zero)
        {
            player.transform.position = playerPosition;
        }
    }
    private void Update()
    {
        if (FindAnyObjectByType<PlayerMovement>())
        {
            playerPosition = player.transform.position;
        }
    }
    private void DisableWall()
    {
        if (wallToDisable != null)
            wallToDisable.SetActive(false);
    }
}