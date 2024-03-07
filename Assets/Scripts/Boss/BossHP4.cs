using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP4 : MonoBehaviour
{
    public float health;
    public float maxhealth;
    Animator anim;
    public Image healthbar;
    public Rigidbody2D rigid;
    public BoxCollider2D box;


    public GameObject clearUI; // 클리어 UI를 가리키는 변수
    private bool isGamePaused = false; // 게임 일시정지 상태를 나타내는 변수

    private float shakeDuration = 0.1f;//테스트
    private float shakeMagnitude = 0.1f;//테스트

    private void Start()
    {
        health = maxhealth;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        clearUI.SetActive(false); // 게임 시작 시 클리어 UI를 숨깁니다.
    }

    private void Update()
    {
        healthbar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);
    }

    public void TakeDamage(float damage)//player magic damaged
    {

        health -= damage;

        if (health <= 0)
        {
            // 체력이 0 이하일 때
            rigid.gravityScale = 1f;
            rigid.constraints = RigidbodyConstraints2D.None;
            box.isTrigger = false;
            this.gameObject.layer = 13;

            //Vector2 newSize = new Vector2(9f, 7f);
            //box.size = newSize;

            anim.SetTrigger("isDead");
            Invoke("Die", 3.0f);
        }
        else//테스트
        {
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()//테스트
    {
        Vector3 originalPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 newPos = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            transform.position = newPos;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }

    void Die()
    {
        // 보스가 죽으면 클리어 UI를 표시하고 게임을 일시정지합니다.
        clearUI.SetActive(true);
        PauseGame();
        Destroy(gameObject);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // 게임 시간을 정지합니다.
        isGamePaused = true;
    }
}