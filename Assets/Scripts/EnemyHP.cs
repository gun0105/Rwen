using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int health;

    private float shakeDuration = 0.1f;//�׽�Ʈ
    private float shakeMagnitude = 0.1f;//�׽�Ʈ

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
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
        Destroy(gameObject);
    }
}