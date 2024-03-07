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
            if (collision.CompareTag("obstacle") || collision.CompareTag("Enemy"))//장애물인 obstacle과 몬스터인 Enemy 태그에게 부딪혓을 경우의 데미지 계산과 애니메이션 재생
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
        
        if (collision.CompareTag("KillBox"))//절벽으로 떨어지면 화면 밖에 존재하는 킬박스에 부딪혀 한번에 체력을 0으로 깎은 후 게임을 종료시킨다.
        {
            HealthManager.health -= 5;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
            }
        }

        if (!Shield.activeShield)//보호막 스킬의 활성화 여부를 따져 플레이어가 데미지를 입는다.
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

    IEnumerator GetHurt()//코루틴을 이용한 무적시간 처리 및 피격 시 투명도 조절 애니메이션 레이어를 불러와 무적 애니메이션 연출
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
