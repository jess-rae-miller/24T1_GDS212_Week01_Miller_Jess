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
        SceneManager.LoadScene(1);
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(2);
    }



}
