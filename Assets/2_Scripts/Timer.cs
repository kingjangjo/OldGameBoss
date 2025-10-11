using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer;
    private TMP_Text timerText;

    void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("00:00.00");
    }
}
