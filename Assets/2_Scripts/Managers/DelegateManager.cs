using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateManager : MonoBehaviour
{
    public static DelegateManager instance;

    public delegate void OnGameClear();
    public OnGameClear onGameClear;

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
