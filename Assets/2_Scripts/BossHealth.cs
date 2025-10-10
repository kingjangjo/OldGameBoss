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
    private int _hp = 100;
    
    // 확실하게 프로퍼티 쓰니까 좀 편하네
    public int HP
    {
        get => _hp;
        set
        {
            _hp = value;
            Debug.Log(_hp);
            UpdateHealthUI();

            if (_hp <= 0)
            {
                // 보스 사망 함수
            }
        }
    }

    public void Start() {
        HP = 100;
    }
    
    public void UpdateHealthUI()
    {
        DOTween.To(() => healthSlider.value, 
            x => healthSlider.value = x, 
            _hp, 1f)
            .SetEase(Ease.OutCubic);
    }
}
