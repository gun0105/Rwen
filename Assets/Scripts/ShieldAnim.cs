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
        if (Shield.activeShield == true)//Shield 스크립트에서 스킬의 활성화 여부를 따져 애니메이션 재생
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

    private void OnTriggerEnter2D(Collider2D collision)//몬스터, 장애물, 보스의 공격 등에 부딪혔을 경우 방어 스킬 종료 애니메이션 작동
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
