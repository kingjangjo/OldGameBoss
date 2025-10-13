using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class MenuSwitch : MonoBehaviour
{
    public GameObject target;
    public GameObject menuHalfAlpha;
    public TMP_Text ResultText;
    public TMP_Text TimerText;
    public TMP_Text RecordText;
    
    void OnEnable()
    {
        DelegateManager.instance.onGameOver += TurnOn;
        DelegateManager.instance.onGameOver += LoseResult;
        DelegateManager.instance.onGameClear += TurnOn;
        DelegateManager.instance.onGameClear += WinResult;
    }

    void OnDisable()
    {
        DelegateManager.instance.onGameOver -= TurnOn;
        DelegateManager.instance.onGameOver -= LoseResult;
        DelegateManager.instance.onGameClear -= TurnOn;
        DelegateManager.instance.onGameClear -= WinResult;
    }
    
    void TurnOn()
    {
        target.SetActive(true);
        menuHalfAlpha.SetActive(true);
    }

    void TurnOff()
    {
        target.SetActive(false);
        menuHalfAlpha.SetActive(false);
    }

    void WinResult()
    {
        ResultText.text = "You Win!";
        ResultText.color = new Color(0, 60/255f, 1);
        TimerText.enabled = false;
        float time = GameManager.instance.timer;
        TimeSpan t = TimeSpan.FromSeconds(time);
        RecordText.text = string.Format("{0:00}:{1:00}.{2:00}",
            Mathf.FloorToInt((float)t.TotalMinutes),
            t.Seconds,               
            t.Milliseconds / 10);

        if (PlayerPrefs.HasKey("RECORD"))
        {
            float OldRecord = PlayerPrefs.GetFloat("RECORD");
            Debug.Log(OldRecord);
        
            if (OldRecord > GameManager.instance.timer)
            {
                RecordText.color = new Color(1, 205 / 255f, 0);
                PlayerPrefs.SetFloat("RECORD", GameManager.instance.timer);
            }
            else
            {
                RecordText.color = Color.white;
            }
        }
        else
        {
            RecordText.color = new Color(1, 205 / 255f, 0);
        }
    }

    void LoseResult()
    {
        ResultText.text = "You Lose!";
        ResultText.color = new Color(215f / 255f, 0, 0);
        TimerText.enabled = false;
        RecordText.gameObject.SetActive(false);
    }
}
