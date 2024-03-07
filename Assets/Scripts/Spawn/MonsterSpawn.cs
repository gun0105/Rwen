using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�׽�Ʈ

public class MonsterSpawn : MonoBehaviour
{
    public GameObject effectPrefab;
    public GameObject aireffectPrefab;//test
    public GameObject monsterPrefab;
    public GameObject AirmonPrefab;//test
    public float minX = 2.9f; // X ��ǥ �ּҰ�
    public float maxX = 7.2f; // X ��ǥ �ִ밪
    public float spawnY = -2.9f; // Y ��ǥ ��

    public float AirspawnY = -0.21f;

    void Start()
    {
        StartCoroutine(SpawnEffectAndMonster());
    }

    IEnumerator SpawnEffectAndMonster()
    {
        while (!PlayerManager.isGameOver)
        {
            string currentScene = SceneManager.GetActiveScene().name;//�׽�Ʈ
            if (currentScene == "3Stage")//�׽�Ʈ
            {
                yield return new WaitForSeconds(20f); // 20�� ���
                Vector3 effectSpawnPosition = GenerateRandomPosition();
                SpawnEffect(effectSpawnPosition);
                yield return new WaitForSeconds(1f);
                SpawnMonsterAtPosition(effectSpawnPosition);
            }
            else if (currentScene == "4Stage")//�׽�Ʈ
            {
                /*yield return new WaitForSeconds(10f); // 10�� ���
                Vector3 effectSpawnPosition = GenerateRandomPosition();
                SpawnEffect(effectSpawnPosition);
                yield return new WaitForSeconds(1f);
                SpawnMonsterAtPosition(effectSpawnPosition);*/
                yield return new WaitForSeconds(10f);
                // �������� ���� �Ǵ� ���� ���� ����
                int randomMonster = Random.Range(0, 2);

                if (randomMonster == 0)
                {
                    Vector3 effectSpawnPosition = GenerateRandomPosition();
                    SpawnEffect(effectSpawnPosition);
                    yield return new WaitForSeconds(1f);
                    SpawnMonsterAtPosition(effectSpawnPosition);
                }
                else
                {
                    Vector3 aireffectSpawnPosition = GenerateRandomAirPosition();
                    SpawnairEffect(aireffectSpawnPosition);
                    yield return new WaitForSeconds(1f);
                    SpawnAirMonsterAtPosition(aireffectSpawnPosition);
                }
            }
        }
    }

    void SpawnEffect(Vector3 position)
    {
        // ����Ʈ ���� ����
        Instantiate(effectPrefab, position, Quaternion.identity);
    }

    void SpawnairEffect(Vector3 position)
    {
        // ���� ����Ʈ ���� ����
        Instantiate(aireffectPrefab, position, Quaternion.identity);
    }

    void SpawnMonsterAtPosition(Vector3 position)
    {
        // ���� ���� ����
        Instantiate(monsterPrefab, position, Quaternion.identity);
    }

    void SpawnAirMonsterAtPosition(Vector3 position)
    {
        // ���� ���� ���� ����
        Instantiate(AirmonPrefab, position, Quaternion.identity);
    }

    Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        return new Vector3(randomX, spawnY, 0f);
    }

    Vector3 GenerateRandomAirPosition()
    {
        float randomX = Random.Range(minX, maxX);
        return new Vector3(randomX, AirspawnY, 0f);
    }
}