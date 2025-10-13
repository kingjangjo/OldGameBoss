using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class SetNewBest : MonoBehaviour
{
    private TMP_Text RecordText;

    void Start()
    {
        RecordText = GetComponent<TMP_Text>();
        RecordText.color = new Color(1, 205 / 255f, 0);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (PlayerPrefs.HasKey("RECORD"))
        {
            float Record = PlayerPrefs.GetFloat("RECORD");
            
            TimeSpan t = TimeSpan.FromSeconds(Record);
            RecordText.text = string.Format("{0:00}:{1:00}.{2:00}",
                Mathf.FloorToInt((float)t.TotalMinutes),
                t.Seconds,
                t.Milliseconds / 10);
        }
        else
        {
            RecordText.text = "No Record!";
        }
    }
}
