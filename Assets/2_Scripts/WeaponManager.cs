using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance { get; private set; }
    
    private bool _canAttack;
    private bool _isAttacking;
    
    // 정작 프로퍼티 만들고 기능 안씀, 언젠간 쓰겟지?
    public bool CanAttack
    {
        get => _canAttack;
        set
        {
            _canAttack = value;
            
            if (_canAttack)
            {
                // true
            }
            else
            {
                // false
            }
        }
    }

    // 이것도 마찬가지다
    public bool IsAttacking
    {
        get => _isAttacking;
        set
        {
            _isAttacking = value;

            if (_isAttacking)
            {
                // true
            }
            else
            {
                // false
            }
        }
    }

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
        
        _canAttack = true;
        _isAttacking = false;
    }
}
