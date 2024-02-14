using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject wallToDisable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if the correct sequence has been played
            if (PianoPuzzleManager.Instance != null && PianoPuzzleManager.Instance.IsCorrectSequencePlayed())
            {
                PlayerPrefs.SetInt("DisableWall", 1);  // Set a PlayerPrefs flag to disable the wall
                SceneManager.LoadScene("MainScene");   // Load the main scene
            }
        }
    }

    public static void DisableWall(GameObject wall)
    {
        if (wall != null)
            wall.SetActive(false);
    }
}