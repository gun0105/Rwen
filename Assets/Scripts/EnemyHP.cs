using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int health;

    private float shakeDuration = 0.1f;//테스트
    private float shakeMagnitude = 0.1f;//테스트

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
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
        Destroy(gameObject);
    }
}