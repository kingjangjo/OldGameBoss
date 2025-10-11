using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextResult : MonoBehaviour
{
    private TMP_Text ResultText;

    void Start()
    {
        ResultText = GetComponent<TextMeshProUGUI>();
        ResultText.text = "";
        DelegateManager.instance.onBossDead += WinResult;
        DelegateManager.instance.onGameOver += LoseResult;
    }
    
    private void WinResult()
    {
        ResultText.text = "YOU WIN!";
    }

    private void LoseResult()
    {
        ResultText.text = "YOU LOSE!";
    }
}
