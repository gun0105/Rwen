using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour

{
    public GameObject hitPrefab; // �Ϲ� ������Ʈ�� hit ������
    public GameObject hitPrefabBoss; // ���� ������Ʈ�� hit ������

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            // �浹�� ������Ʈ�� Boss �±׸� ���� ���, hitPrefabBoss�� �����մϴ�.
            if (hitPrefabBoss != null)
            {
                Bounds bounds = other.bounds;
                Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x),Random.Range(bounds.min.y, bounds.max.y));
                Instantiate(hitPrefabBoss, randomPosition, Quaternion.identity);
            }
        }

        if (other.CompareTag("2_Boss"))
        {
            // �浹�� ������Ʈ�� 2_Boss �±׸� ���� ���, hitPrefabBoss�� �����մϴ�.
            if (hitPrefabBoss != null)
            {
                Bounds bounds = other.bounds;
                Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
                Instantiate(hitPrefabBoss, randomPosition, Quaternion.identity);
            }
        }

        if (other.CompareTag("3_Boss"))
        {
            // �浹�� ������Ʈ�� 3_Boss �±׸� ���� ���, hitPrefabBoss�� �����մϴ�.
            if (hitPrefabBoss != null)
            {
                Bounds bounds = other.bounds;
                Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
                Instantiate(hitPrefabBoss, randomPosition, Quaternion.identity);
            }
        }

        if (other.CompareTag("4_Boss"))
        {
            // �浹�� ������Ʈ�� 3_Boss �±׸� ���� ���, hitPrefabBoss�� �����մϴ�.
            if (hitPrefabBoss != null)
            {
                Bounds bounds = other.bounds;
                Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
                Instantiate(hitPrefabBoss, randomPosition, Quaternion.identity);
            }
        }

        if (other.CompareTag("Enemy") || other.CompareTag("obstacle"))
        {
            // �浹�� ������Ʈ�� Enemy, obstacle�� �±׸� ������ �ִٸ� hitPrefab�� �����մϴ�.
            if (hitPrefab != null)
            {
                Bounds bounds = other.bounds;
                Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x),Random.Range(bounds.min.y, bounds.max.y));
                Instantiate(hitPrefab, randomPosition, Quaternion.identity);
            }
        }
    }
}