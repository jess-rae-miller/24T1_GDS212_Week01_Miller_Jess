using UnityEngine;
using UnityEngine.UI;

public class SwitchPages : MonoBehaviour
{
    [SerializeField]
    public RawImage[] pages; // Drag and drop your Raw Image elements here in the inspector
    private int currentPageIndex = 0;

    void Start()
    {
        UpdateImage();
    }

    void UpdateImage()
    {
        // Disable all Raw Images
        foreach (RawImage page in pages)
        {
            page.gameObject.SetActive(false);
        }

        // Enable the current Raw Image
        pages[currentPageIndex].gameObject.SetActive(true);
    }

    public void OnButtonClick()
    {
        currentPageIndex = (currentPageIndex + 1) % pages.Length;
        UpdateImage();
    }
}
