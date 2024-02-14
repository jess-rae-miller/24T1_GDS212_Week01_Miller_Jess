using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PianoPuzzleManager : MonoBehaviour
{
    public static PianoPuzzleManager Instance;

    [SerializeField] private TextMeshProUGUI incorrectText;
    [SerializeField] private TextMeshProUGUI correctText;
    [SerializeField] private AudioSource correctAudio;

    private List<string> sequence = new List<string> { "F", "A", "F", "E", "F", "A", "E", "D" };
    private int currentIndex = 0;
    private bool isCorrectSequencePlayed = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        incorrectText.enabled = false;
        correctText.enabled = false;
    }

    public void CheckSequence(string note)
    {
        if (isCorrectSequencePlayed) return;

        if (note == sequence[currentIndex])
        {
            currentIndex++;

            if (currentIndex == sequence.Count)
            {
                Debug.Log("Puzzle completed!");

                if (correctAudio != null)
                    correctAudio.Play();

                StartCoroutine(DisplayCorrectText());

                isCorrectSequencePlayed = true;
                currentIndex = 0;
            }
        }
        else
        {
            StartCoroutine(DisplayIncorrectText());
            currentIndex = 0;
        }
    }

    public bool IsCorrectSequencePlayed()
    {
        return isCorrectSequencePlayed;
    }

    private IEnumerator DisplayIncorrectText()
    {
        incorrectText.enabled = true;
        yield return new WaitForSeconds(0.5f);
        FadeOutText(incorrectText);
    }

    private IEnumerator DisplayCorrectText()
    {
        correctText.enabled = true;
        yield return new WaitForSeconds(2f);
        FadeOutText(correctText);
    }

    private void FadeOutText(TextMeshProUGUI text)
    {
        StartCoroutine(FadeTextToZeroAlpha(text, 1f));
    }

    private IEnumerator FadeTextToZeroAlpha(TextMeshProUGUI text, float fadeDuration)
    {
        float elapsedTime = 0f;

        Color originalColor = text.color;

        while (elapsedTime < fadeDuration)
        {
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1, 0, elapsedTime / fadeDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        text.enabled = false;
        text.color = originalColor;
    }
}