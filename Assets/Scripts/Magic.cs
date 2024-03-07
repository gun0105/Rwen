using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float lifetime;
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("Destroy", lifetime);//�� ������ �Ѿ��� ���󰡴� ���� �����ϱ� ���� Invoke�� ����Ͽ� lifetime�� ���� �� �Ѿ� ����
    }
    private void OnTriggerEnter2D(Collider2D collision)//�±׷� �浹�� ������ ���Ϳ� ������ HP ��ũ��Ʈ�� ������ �������� �����
    {
        EnemyHP enemy = collision.GetComponent<EnemyHP>();
        BossHP boss = collision.GetComponent<BossHP>();
        BossHP2 boss_2 = collision.GetComponent<BossHP2>();
        BossHP3 boss_3 = collision.GetComponent<BossHP3>();
        BossHP4 boss_4 = collision.GetComponent<BossHP4>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            boss.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("2_Boss"))
        {
            boss_2.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("3_Boss"))
        {
            boss_3.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("4_Boss"))
        {
            boss_4.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(gameObject);
    }
}
