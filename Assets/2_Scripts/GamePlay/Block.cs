using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using DG.Tweening;

public enum BlockType
{
    Normal,
    Attack
}

public class Block : MonoBehaviour, IHitObject
{
    private BlockType blockType;
    private SpriteRenderer spriteRenderer;
    private GameObject boss;

    private int currentBrokenCount;
    private int maxBrokenCount;

    public bool isThrown;

    public GameObject destroyEffect;

    // 처음 시작시 떨어지는 블록 거르기
    public bool ignoreLineCheck = true;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int num = Random.Range(0, 10);

        // 20% 확률로 공격 블럭
        if (num >= 8)
        {
            spriteRenderer.color = Color.black;
            transform.tag = "AttackBlock";
            blockType = BlockType.Attack;
        }
        else
        {
            blockType = BlockType.Normal;
        }

        boss = GameObject.FindGameObjectWithTag("Boss");
        currentBrokenCount = 0;
        maxBrokenCount = 2;
    }

    void Update()
    {
        // 만약 블럭이 떨어지면 없어지게 (근데 떨어질 일이 이제 없긴 하다)
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("AttackBlock"))
        {
            ignoreLineCheck = false;
        }
    }
    
    public void HitObject()
    {
        // 일반블럭이면
        if (blockType == BlockType.Normal)
        {
            HitDefaultBlock();
        }
        
        // 공격블럭이면
        else if (blockType == BlockType.Attack)
        {
            HitAttackBlock();
        }
    }
    
    private void HitDefaultBlock()
    {
        // 아직 덜 부셔졌으면
        if (currentBrokenCount < maxBrokenCount)
        {
            currentBrokenCount++;
            
            // 테스트용 색깔
            spriteRenderer.color = new Color(158f / 255f, 166f / 255f, 148f / 255f);
        }
        
        // 다 부셔졌으면
        if (currentBrokenCount == maxBrokenCount)
        {
            // 펑
            var eff = Instantiate(destroyEffect, this.transform.position, Quaternion.identity);
            Destroy(eff, 0.5f);
            Destroy(gameObject);
        }
    }
    
    private void HitAttackBlock()
    {
        PolygonCollider2D polyCollider = transform.GetComponent<PolygonCollider2D>();
        polyCollider.isTrigger = true;
        
        // 보스쪽으로 가서 공격하기 (펑)
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(boss.transform.position, 0.35f, false));
        sequence.AppendCallback(() => Destroy(gameObject));
        sequence.OnComplete(() => boss.GetComponent<BossHealth>().HP += 4);
    }
}
