using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSkill : MonoBehaviour
{
    public GameObject lightningPrefab; // ����߸� ���� ��� ������
    public float cooldown = 20f; // ��ų ��Ÿ��
    public float spawnDelay = 0.5f; // ���� ��� ������ ������
    public float damageRadius = 1.5f; // �������� ���� ����
    public int lightningdamage = 60;

    private float lastUsedTime; // ������ ��ų ��� �ð�
    private Vector3[] spawnPositions; // ���� ����� ����߸� ��ġ��

    private int currentSpawnIndex = 0; // ���� ����߸��� ���� ��� �ε���

    private void Start()
    {
        lastUsedTime = -cooldown; // ���� �ð��� �����Ͽ� ó���� ��ų ��� �����ϵ��� ����

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
        currentSpawnIndex = 0; // �ε��� �ʱ�ȭ

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
                // �������� ������ ���� �߰�
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
            Invoke("DropLightning", spawnDelay); // ���� ���� ��� ����߸���
        }
    }
}