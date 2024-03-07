using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningFire : MonoBehaviour
{
    public Rigidbody2D rb;
    public float lifetime = 1.5f;
    public int damage = 60;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHP enemy = collision.GetComponent<EnemyHP>();
        BossHP boss = collision.GetComponent<BossHP>();
        BossHP2 boss_2 = collision.GetComponent<BossHP2>();
        BossHP3 boss_3 = collision.GetComponent<BossHP3>();
        BossHP4 boss_4 = collision.GetComponent<BossHP4>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
        }
        
        if (collision.gameObject.CompareTag("Boss"))
        {
            boss.TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("2_Boss"))
        {
            boss_2.TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("3_Boss"))
        {
            boss_3.TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("4_Boss"))
        {
            boss_4.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(gameObject);
    }
}