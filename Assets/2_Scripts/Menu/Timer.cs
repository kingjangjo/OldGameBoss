using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private TMP_Text timerText;
    private bool isGoing;

    void Start()
    {
        isGoing = true;
        timerText = GetComponent<TMP_Text>();
        
        DelegateManager.instance.onGameClear += StopTimer;
        DelegateManager.instance.onGameOver += StopTimer;
    }

    void OnEnable()
    {
        DelegateManager.instance.onGameClear += StopTimer;
        DelegateManager.instance.onGameOver += StopTimer;
    }

    void OnDisable()
    {
        DelegateManager.instance.onGameClear -= StopTimer;
        DelegateManager.instance.onGameOver -= StopTimer;
    }
    
    void Update()
    {
        if (isGoing)
        {
            GameManager.instance.timer += Time.deltaTime;
            float time = GameManager.instance.timer;
            TimeSpan t = TimeSpan.FromSeconds(time);
            timerText.text = string.Format("{0:00}:{1:00}.{2:00}",
                Mathf.FloorToInt((float)t.TotalMinutes),
                t.Seconds,               
                t.Milliseconds / 10);
        }
    }

    private void StopTimer()
    {
        isGoing = false;

        if (PlayerPrefs.HasKey("RECORD"))
        {
            float OldNewBest = PlayerPrefs.GetFloat("RECORD");

            if (OldNewBest > GameManager.instance.timer)
            {
                PlayerPrefs.SetFloat("RECORD", GameManager.instance.timer);
                GameManager.instance.isNewBest = true;
            }
        }
        else {
            PlayerPrefs.SetFloat("RECORD", GameManager.instance.timer);
            GameManager.instance.isNewBest = true;
        }
    }
}
