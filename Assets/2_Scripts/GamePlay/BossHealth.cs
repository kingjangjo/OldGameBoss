using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.PlayerLoop;

public class BossHealth : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHP = 100;
    private int _hp = 100;
    
    // 확실하게 프로퍼티 쓰니까 좀 편하네
    public int HP
    {
        get => _hp;
        set
        {
            _hp = Mathf.Clamp(value, 0, maxHP);
            Debug.Log(_hp);
            UpdateHealthUI();

            if (_hp <= 0)
            {
                if (!GameManager.instance.EndFlag)
                {
                    DelegateManager.instance.onGameClear();
                    GameManager.instance.EndFlag = true;
                }
            }
        }
    }

    public void Start()
    {
        HP = maxHP;
        healthSlider.maxValue = maxHP;
    }
    
    private void UpdateHealthUI()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => healthSlider.value,
                x => healthSlider.value = x,
                _hp
                , 1f)
            .SetEase(Ease.OutCubic));
        
        sequence.OnComplete(() =>
        {
            if (healthSlider.value <= 0.01f)
            {
                healthSlider.fillRect.gameObject.SetActive(false);
            }
        });
    }
}
