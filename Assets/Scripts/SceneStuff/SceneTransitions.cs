using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
     public void OptionsScene()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(3);
    }
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public void LoadIntroScene()
    {
        SceneManager.LoadScene(1);
    }
}
