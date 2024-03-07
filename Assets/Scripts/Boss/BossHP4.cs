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


    public GameObject clearUI; // Ŭ���� UI�� ����Ű�� ����
    private bool isGamePaused = false; // ���� �Ͻ����� ���¸� ��Ÿ���� ����

    private float shakeDuration = 0.1f;//�׽�Ʈ
    private float shakeMagnitude = 0.1f;//�׽�Ʈ

    private void Start()
    {
        health = maxhealth;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        clearUI.SetActive(false); // ���� ���� �� Ŭ���� UI�� ����ϴ�.
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
            // ü���� 0 ������ ��
            rigid.gravityScale = 1f;
            rigid.constraints = RigidbodyConstraints2D.None;
            box.isTrigger = false;
            this.gameObject.layer = 13;

            //Vector2 newSize = new Vector2(9f, 7f);
            //box.size = newSize;

            anim.SetTrigger("isDead");
            Invoke("Die", 3.0f);
        }
        else//�׽�Ʈ
        {
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()//�׽�Ʈ
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
        // ������ ������ Ŭ���� UI�� ǥ���ϰ� ������ �Ͻ������մϴ�.
        clearUI.SetActive(true);
        PauseGame();
        Destroy(gameObject);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // ���� �ð��� �����մϴ�.
        isGamePaused = true;
    }
}