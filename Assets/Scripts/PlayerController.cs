using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 500f;//점프력

    private Rigidbody2D Rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public bool GroundOn;//땅 위 판정
    public bool doublejump; //2단 점프
    public LayerMask GroundCheak;//땅 위 체크

    public bool NonjumpOn;

    public LayerMask NonjumpCheak;//점프 제한

    private Collider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundOn = Physics2D.IsTouchingLayers(myCollider, GroundCheak); //Ground Layers 위에 있는지 체크를 위한 선언
        NonjumpOn = Physics2D.IsTouchingLayers(myCollider, NonjumpCheak);//nonjump Layers 체크
        anim.SetBool("Jump", !GroundOn);
        anim.SetBool("Jump_2", !GroundOn && !doublejump);
        if (Input.GetKeyDown(KeyCode.X) && !PlayerManager.isGameOver && StartCounting.isCount)//x키, 살아있을경우
        {
            if (GroundOn && !NonjumpOn)
            {
                Rigid.velocity = Vector2.zero;
                Rigid.AddForce(new Vector2(0,jumpForce));
                doublejump = false;
            }
            else if (doublejump && !NonjumpOn)
            {
                Rigid.velocity = Vector2.zero;
                Rigid.AddForce(new Vector2(0, jumpForce));
                doublejump = false;
            }
        }
        if (GroundOn)
        {
            doublejump = true;
            anim.SetBool("Jump", false);
            anim.SetBool("Jump_2", false);
        }
    }
}