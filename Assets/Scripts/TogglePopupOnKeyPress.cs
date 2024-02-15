using UnityEngine;
using UnityEngine.UI;

public class TogglePopupOnKeyPress : MonoBehaviour
{
    public GameObject popupUI;
    private bool isPopupVisible = false;

    void Start()
    {
        if (popupUI == null)
        {
            Debug.LogError("Popup UI is not assigned!");
            return;
        }

        // Hide the popup initially
        popupUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInCollider())
        {
            TogglePopupVisibility();
        }
    }

    void TogglePopupVisibility()
    {
        isPopupVisible = !isPopupVisible;
        popupUI.SetActive(isPopupVisible);
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