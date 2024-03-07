using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 500f;//������

    private Rigidbody2D Rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public bool GroundOn;//�� �� ����
    public bool doublejump; //2�� ����
    public LayerMask GroundCheak;//�� �� üũ

    public bool NonjumpOn;

    public LayerMask NonjumpCheak;//���� ����

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
        GroundOn = Physics2D.IsTouchingLayers(myCollider, GroundCheak); //Ground Layers ���� �ִ��� üũ�� ���� ����
        NonjumpOn = Physics2D.IsTouchingLayers(myCollider, NonjumpCheak);//nonjump Layers üũ
        anim.SetBool("Jump", !GroundOn);
        anim.SetBool("Jump_2", !GroundOn && !doublejump);
        if (Input.GetKeyDown(KeyCode.X) && !PlayerManager.isGameOver && StartCounting.isCount)//xŰ, ����������
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