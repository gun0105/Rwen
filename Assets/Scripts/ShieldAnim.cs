using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnim : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Shield.activeShield == true)//Shield ��ũ��Ʈ���� ��ų�� Ȱ��ȭ ���θ� ���� �ִϸ��̼� ���
        {
            anim.SetBool("isStarting", true);
            Invoke("Ing", 0.5f);
        } else if (Shield.activeShield == false)
        {
            anim.SetBool("isFinish",true);
        }
    }

    void Ing()
    {
        anim.SetBool("isIng", true);
    }

    void Finishout()
    {
        anim.SetBool("isFinish", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)//����, ��ֹ�, ������ ���� � �ε����� ��� ��� ��ų ���� �ִϸ��̼� �۵�
    {
        if (Shield.activeShield)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("obstacle") || collision.CompareTag("Normalattack") || collision.CompareTag("Strongattack"))
            {
                anim.SetBool("isFinish", true);
            }
        }
    }

}
