using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponRotation : MonoBehaviour
{
    private SpriteRenderer weaponSpriteRenderer;

    void Start()
    {
        weaponSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (WeaponManager.instance.CanAttack)
        {
            WeaponAnimation();
        }
    }

    private void WeaponAnimation()
    {
        // 공격 가능 상태랑 공격하는 상태 다른거임 ㅇㅇ
        // 코드 알아서 보셈
        int flip = weaponSpriteRenderer.flipX ? -1 : 1;
        
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = currentRotation * Quaternion.Euler(0, 0, 60 * flip);
        Quaternion readyRotation = currentRotation * Quaternion.Euler(0, 0, -80 * flip);
            
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() => WeaponManager.instance.CanAttack = false);
        sequence.Append(transform.DORotate(readyRotation.eulerAngles, 0.5f));
        sequence.AppendCallback(() => WeaponManager.instance.IsAttacking = true);
        sequence.Append(transform.DORotate(targetRotation.eulerAngles, 0.3f));
        sequence.AppendCallback(() => WeaponManager.instance.IsAttacking = false);
        sequence.Append(transform.DORotate(currentRotation.eulerAngles, 0.4f));
        sequence.OnComplete(() => WeaponManager.instance.CanAttack = true);
        //sequence.AppendCallback(() => WeaponManager.instance.CanAttack = false);
        //sequence.Append(transform.DORotate(readyRotation.eulerAngles, 0.3f));
        //sequence.AppendCallback(() => WeaponManager.instance.IsAttacking = true);
        //sequence.Append(transform.DORotate(targetRotation.eulerAngles, 0.2f));
        //sequence.AppendCallback(() => WeaponManager.instance.IsAttacking = false);
        //sequence.Append(transform.DORotate(currentRotation.eulerAngles, 0.3f));
        //sequence.OnComplete(() => WeaponManager.instance.CanAttack = true);
    }
}
