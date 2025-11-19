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
    public int maxHP = 20;
    private int _hp = 0;
    public GameObject blockSet;
    
    // 확실하게 프로퍼티 쓰니까 좀 편하네
    public int HP
    {
        get => _hp;
        set
        {
            _hp = Mathf.Clamp(value, 0, maxHP);
            Debug.Log(_hp);
            UpdateHealthUI();

            //if (_hp <= 0)
            //{
            //    if (!GameManager.instance.EndFlag)
            //    {
            //        DelegateManager.instance.onGameClear();
            //        GameManager.instance.EndFlag = true;
            //    }
            //}
            if (_hp >= maxHP)
            {
                SetBlock();
                HP = 0;
                maxHP *= 2;
                healthSlider.maxValue = maxHP;
            }
        }
    }

    public void Start()
    {
        HP = 0;
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
        
        //sequence.OnComplete(() =>
        //{
        //    if (healthSlider.value <= 0.01f)
        //    {
        //        healthSlider.fillRect.gameObject.SetActive(false);
        //    }
        //});
    }

    private void SetBlock()
    {
        var blockSetter = Instantiate(blockSet, new Vector3(0, 2.5f, 0), Quaternion.identity);
        DOTween.To(() => blockSetter.transform.position,
                x => blockSetter.transform.position = x,
                blockSetter.transform.position + new Vector3(0, -7.5f, 0)
                , 2f)
            .SetEase(Ease.OutCubic);
        Destroy(blockSetter.gameObject, 2f);
    }
}
