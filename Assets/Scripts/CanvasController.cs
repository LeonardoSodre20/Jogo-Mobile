using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    
    void Update()
    {
        
    }

    public void NextScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
