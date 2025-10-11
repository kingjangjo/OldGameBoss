using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHalfAlphaSwitch : MonoBehaviour
{
    void Start()
    {
        DelegateManager.instance.onGameOver += TurnOn;
        DelegateManager.instance.onBossDead += TurnOn;
    }
    void TurnOn()
    {
        gameObject.SetActive(true);
    }

    void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
