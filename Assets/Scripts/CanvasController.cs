using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    
    public void RestartScene(string sceneGame)
    {
        SceneManager.LoadScene(sceneGame);
        Time.timeScale = 1;
    }

    public void NextScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void Home(string sceneMenu)
    {
        SceneManager.LoadScene(sceneMenu);
    }
}
