using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitBox : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private bool hitFlag = false;
    public AudioSource audio;

    public GameObject hitEffect;
    
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        // hitFlag = 단일공격 (1번 공격 = true)
        if (WeaponManager.instance.IsAttacking && !hitFlag)
        {
            // 망치의 충돌구역
            Collider2D hit = Physics2D.OverlapBox(transform.position, 
                boxCollider.size * 0.6f, 
                transform.eulerAngles.z, 
                LayerMask.GetMask("Floor"));
            
            // 뭐가 맞으면
            if (hit)
            {
                // 인터페이스를 통한 블럭 구분
                IHitObject hitObject = hit.GetComponent<IHitObject>();
                Block hitBlock = hit.GetComponent<Block>();
                
                if (hitObject != null)
                {
                    hitObject.HitObject();

                    audio.Play();

                    var eff = Instantiate(hitEffect, this.transform.position, Quaternion.identity);
                    Destroy(eff, 0.5f);

                    if (hitBlock != null)
                    {
                        hitBlock.isThrown = true;
                    }
                    
                    hitFlag = true;   
                }
            }
        }
        
        // 공격가능상태(CanAttack)이 true면 hitFlag = false로
        if (WeaponManager.instance.CanAttack)
        {
            hitFlag = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (boxCollider != null)
        {
            Gizmos.DrawWireCube(transform.position, boxCollider.size * 0.6f);
        }
    }
}
