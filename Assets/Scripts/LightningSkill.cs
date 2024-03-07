using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSkill : MonoBehaviour
{
    public GameObject lightningPrefab; // 떨어뜨릴 번개 기둥 프리팹
    public float cooldown = 20f; // 스킬 쿨타임
    public float spawnDelay = 0.5f; // 번개 기둥 사이의 딜레이
    public float damageRadius = 1.5f; // 데미지를 입힐 범위
    public int lightningdamage = 60;

    private float lastUsedTime; // 마지막 스킬 사용 시간
    private Vector3[] spawnPositions; // 번개 기둥을 떨어뜨릴 위치들

    private int currentSpawnIndex = 0; // 현재 떨어뜨리는 번개 기둥 인덱스

    private void Start()
    {
        lastUsedTime = -cooldown; // 시작 시간을 조절하여 처음에 스킬 사용 가능하도록 설정

        spawnPositions = new Vector3[]
        {
            new Vector3(-4f, -3.7f, 0f),
            new Vector3(-0.5f, -3.7f, 0f),
            new Vector3(3.5f, -3.7f, 0f),
            new Vector3(7.5f, -3.7f, 0f)
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastUsedTime >= cooldown && !PlayerManager.isGameOver && !PauseOpen.isOpen && StartCounting.isCount)
        {
            UseSkill();
        }
    }

    private void UseSkill()
    {
        lastUsedTime = Time.time;
        currentSpawnIndex = 0; // 인덱스 초기화

        DropLightning();
    }

    private void DropLightning()
    {
        if (currentSpawnIndex < spawnPositions.Length)
        {
            Vector3 position = spawnPositions[currentSpawnIndex];
            Instantiate(lightningPrefab, position, Quaternion.identity);

            Collider[] hitColliders = Physics.OverlapSphere(position, damageRadius);
            foreach (Collider hitCollider in hitColliders)
            {
                // 데미지를 입히는 로직 추가
                EnemyHP enemy = hitCollider.GetComponent<EnemyHP>();
                if (hitCollider.gameObject.CompareTag("Enemy"))
                    {
                        enemy.TakeDamage(lightningdamage);
                    }
                /*BossHP boss = hitCollider.GetComponent<BossHP>();
                if (hitCollider.gameObject.CompareTag("Boss"))
                    {
                        boss.TakeDamage(lightningdamage);
                    }*/
            }
            currentSpawnIndex++;
            Invoke("DropLightning", spawnDelay); // 다음 번개 기둥 떨어뜨리기
        }
    }
}