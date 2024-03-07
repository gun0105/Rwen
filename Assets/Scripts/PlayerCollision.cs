using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;
    public Image Blood;

    Coroutine coroutine;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 8, false);
        Physics2D.IgnoreLayerCollision(7, 8, false);
        Physics2D.IgnoreLayerCollision(11, 8, false);
        Physics2D.IgnoreLayerCollision(12, 8, false);
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3) && HealthManager.health < 5)
        {
            HealthManager.health++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Shield.activeShield)
        {
            if (collision.CompareTag("obstacle") || collision.CompareTag("Enemy"))//��ֹ��� obstacle�� ������ Enemy �±׿��� �ε����� ����� ������ ���� �ִϸ��̼� ���
            {
                anim.SetTrigger("Damage");
                HealthManager.health--;
                StartCoroutine(ShowBlood());//test

                if (HealthManager.health <= 0)
                {
                    rigid.gravityScale = 1f;
                    this.gameObject.layer = 13;
                    anim.SetTrigger("Die");
                    PlayerManager.isGameOver = true;
                }
                else
                {
                    coroutine = StartCoroutine(GetHurt());
                }
            }
        }
        
        if (collision.CompareTag("KillBox"))//�������� �������� ȭ�� �ۿ� �����ϴ� ų�ڽ��� �ε��� �ѹ��� ü���� 0���� ���� �� ������ �����Ų��.
        {
            HealthManager.health -= 5;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
            }
        }

        if (!Shield.activeShield)//��ȣ�� ��ų�� Ȱ��ȭ ���θ� ���� �÷��̾ �������� �Դ´�.
        {
            if (collision.CompareTag("Normalattack"))
            {
                anim.SetTrigger("Damage");
                HealthManager.health--;
                StartCoroutine(ShowBlood());//test
                if (HealthManager.health <= 0)
                {
                    anim.SetTrigger("Die");
                    this.gameObject.layer = 13;
                    PlayerManager.isGameOver = true;
                }
                else
                {
                    coroutine = StartCoroutine(GetHurt());
                }
            }
        }

        if (!Shield.activeShield)
        {
            if (collision.CompareTag("Strongattack"))
            {
                anim.SetTrigger("Damage");
                HealthManager.health -= 2;
                StartCoroutine(ShowBlood());//test
                if (HealthManager.health <= 0)
                {
                    anim.SetTrigger("Die");
                    this.gameObject.layer = 13;
                    PlayerManager.isGameOver = true;
                }
                else
                {
                    coroutine = StartCoroutine(GetHurt());
                }
            }
        }
    }

    public void OnDestroy()
    {
        if(coroutine != null)
            StopCoroutine(coroutine); 
    }

    IEnumerator GetHurt()//�ڷ�ƾ�� �̿��� �����ð� ó�� �� �ǰ� �� ���� ���� �ִϸ��̼� ���̾ �ҷ��� ���� �ִϸ��̼� ����
    {
        if (coroutine != null)
        {
            Debug.Log(123243);
            yield break;
        }

        Physics2D.IgnoreLayerCollision(6, 8);
        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(11, 8);
        Physics2D.IgnoreLayerCollision(12, 8);
        anim.SetLayerWeight(1, 1);
        yield return new WaitForSeconds(1.5f);
        Physics2D.IgnoreLayerCollision(6, 8, false);
        Physics2D.IgnoreLayerCollision(7, 8, false);
        Physics2D.IgnoreLayerCollision(11, 8, false);
        Physics2D.IgnoreLayerCollision(12, 8, false);
        anim.SetLayerWeight(1, 0);
        coroutine = null;
    }

    IEnumerator ShowBlood() // test
    {
        Blood.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.3f);
        Blood.color = Color.clear;
    }
}
