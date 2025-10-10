using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed;

    private int jumpCount;
    private int maxJumpCount;

    private GameObject Weapon;
    
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer weaponSpriteRenderer;
    private RaycastHit2D hit;
    
    public PhysicsMaterial2D NoFriction;
    public PhysicsMaterial2D DefaultFriction;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Weapon = transform.GetChild(0).GetChild(0).gameObject;
        weaponSpriteRenderer = Weapon.GetComponent<SpriteRenderer>();

        speed = 3;
        maxJumpCount = 1;
    }
    
    void Update()
    {
        // 점프 시
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 박스캐스트로 판별
            RaycastHit2D hit = Physics2D.BoxCast((Vector2)transform.position + Vector2.down * 0.1f,
                new Vector2(spriteRenderer.size.x, 0.3f),
                0f,
                Vector2.down,
                0.1f,
                LayerMask.GetMask("Floor"));
            
            // 땅이면 초기화
            if (hit.collider != null)
            {
                jumpCount = 0;
                rigid.sharedMaterial = DefaultFriction;
            }

            if (jumpCount < maxJumpCount)
            {
                jumpCount++;
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
                rigid.sharedMaterial = NoFriction;
            }
        }
    }

    void FixedUpdate()
    {
        // 움직이는 거
        float inputX = Input.GetAxisRaw("Horizontal");
        
        // 왼쪽으로 움직이면
        if (inputX < 0 && WeaponManager.instance.CanAttack)
        {
            spriteRenderer.flipX = true;
            weaponSpriteRenderer.flipX = true;
            Weapon.transform.localPosition = new Vector2(-0.8f, Weapon.transform.localPosition.y);
        }
        
        // 오른쪽으로 움직이면
        else if (inputX > 0 && WeaponManager.instance.CanAttack)
        {
            spriteRenderer.flipX = false;
            weaponSpriteRenderer.flipX = false;
            Weapon.transform.localPosition = new Vector2(0.8f, Weapon.transform.localPosition.y);
            
        }
        
        // 움직이는 거
        rigid.velocity = new Vector2(inputX * speed, rigid.velocity.y);
    }
}
