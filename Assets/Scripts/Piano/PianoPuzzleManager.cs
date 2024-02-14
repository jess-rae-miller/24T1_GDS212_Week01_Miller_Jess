using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzleManager : MonoBehaviour
{
    public static PianoPuzzleManager Instance;

    private List<string> sequence = new List<string> { "F", "A", "F", "E", "F", "A", "E", "D" };
    private int currentIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CheckSequence(string note)
    {
        if (note == sequence[currentIndex])
        {
            currentIndex++;

            if (currentIndex == sequence.Count)
            {
                // Puzzle completed, add your logic here
                Debug.Log("Puzzle completed!");
                currentIndex = 0; // Reset the index for the next round
            }
        }
        else
        {
            // Incorrect note, reset the sequence
            Debug.Log("Incorrect note, resetting sequence");
            currentIndex = 0;
        }
    }
}