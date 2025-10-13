using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyButton : MonoBehaviour
{
    public void LobbyButtonClicked()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
