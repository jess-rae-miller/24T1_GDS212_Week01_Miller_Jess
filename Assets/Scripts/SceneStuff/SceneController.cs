using UnityEngine;

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
                DisableWall();
            }
        }
    }

    private void DisableWall()
    {
        if (wallToDisable != null)
            wallToDisable.SetActive(false);
    }
}