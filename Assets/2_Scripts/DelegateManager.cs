using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateManager : MonoBehaviour
{
    public static DelegateManager instance;

    public delegate void OnBossDead();
    public OnBossDead onBossDead;

    public delegate void OnGameOver();
    public OnGameOver onGameOver;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
