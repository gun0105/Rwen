using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour

{
    public GameObject hitPrefab; // 일반 오브젝트용 hit 프리팹
    public GameObject hitPrefabBoss; // 보스 오브젝트용 hit 프리팹

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            // 충돌한 오브젝트가 Boss 태그를 가진 경우, hitPrefabBoss를 생성합니다.
            if (hitPrefabBoss != null)
            {
                Bounds bounds = other.bounds;
                Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x),Random.Range(bounds.min.y, bounds.max.y));
                Instantiate(hitPrefabBoss, randomPosition, Quaternion.identity);
            }
        }

        if (other.CompareTag("2_Boss"))
        {
            // 충돌한 오브젝트가 2_Boss 태그를 가진 경우, hitPrefabBoss를 생성합니다.
            if (hitPrefabBoss != null)
            {
                Bounds bounds = other.bounds;
                Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
                Instantiate(hitPrefabBoss, randomPosition, Quaternion.identity);
            }
        }

        if (other.CompareTag("3_Boss"))
        {
            // 충돌한 오브젝트가 3_Boss 태그를 가진 경우, hitPrefabBoss를 생성합니다.
            if (hitPrefabBoss != null)
            {
                Bounds bounds = other.bounds;
                Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
                Instantiate(hitPrefabBoss, randomPosition, Quaternion.identity);
            }
        }

        if (other.CompareTag("4_Boss"))
        {
            // 충돌한 오브젝트가 3_Boss 태그를 가진 경우, hitPrefabBoss를 생성합니다.
            if (hitPrefabBoss != null)
            {
                Bounds bounds = other.bounds;
                Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
                Instantiate(hitPrefabBoss, randomPosition, Quaternion.identity);
            }
        }

        if (other.CompareTag("Enemy") || other.CompareTag("obstacle"))
        {
            // 충돌한 오브젝트가 Enemy, obstacle의 태그를 가지고 있다면 hitPrefab을 생성합니다.
            if (hitPrefab != null)
            {
                Bounds bounds = other.bounds;
                Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x),Random.Range(bounds.min.y, bounds.max.y));
                Instantiate(hitPrefab, randomPosition, Quaternion.identity);
            }
        }
    }
}