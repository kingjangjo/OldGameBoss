using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("RestartScene");
    }
    
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "RestartScene")
        {
            SceneManager.LoadScene("GamePlayScene");
        }
    }
}
