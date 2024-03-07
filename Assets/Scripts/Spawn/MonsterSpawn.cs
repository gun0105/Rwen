using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//테스트

public class MonsterSpawn : MonoBehaviour
{
    public GameObject effectPrefab;
    public GameObject aireffectPrefab;//test
    public GameObject monsterPrefab;
    public GameObject AirmonPrefab;//test
    public float minX = 2.9f; // X 좌표 최소값
    public float maxX = 7.2f; // X 좌표 최대값
    public float spawnY = -2.9f; // Y 좌표 값

    public float AirspawnY = -0.21f;

    void Start()
    {
        StartCoroutine(SpawnEffectAndMonster());
    }

    IEnumerator SpawnEffectAndMonster()
    {
        while (!PlayerManager.isGameOver)
        {
            string currentScene = SceneManager.GetActiveScene().name;//테스트
            if (currentScene == "3Stage")//테스트
            {
                yield return new WaitForSeconds(20f); // 20초 대기
                Vector3 effectSpawnPosition = GenerateRandomPosition();
                SpawnEffect(effectSpawnPosition);
                yield return new WaitForSeconds(1f);
                SpawnMonsterAtPosition(effectSpawnPosition);
            }
            else if (currentScene == "4Stage")//테스트
            {
                /*yield return new WaitForSeconds(10f); // 10초 대기
                Vector3 effectSpawnPosition = GenerateRandomPosition();
                SpawnEffect(effectSpawnPosition);
                yield return new WaitForSeconds(1f);
                SpawnMonsterAtPosition(effectSpawnPosition);*/
                yield return new WaitForSeconds(10f);
                // 랜덤으로 몬스터 또는 에어 몬스터 선택
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
        // 이펙트 생성 로직
        Instantiate(effectPrefab, position, Quaternion.identity);
    }

    void SpawnairEffect(Vector3 position)
    {
        // 에어 이펙트 생성 로직
        Instantiate(aireffectPrefab, position, Quaternion.identity);
    }

    void SpawnMonsterAtPosition(Vector3 position)
    {
        // 몬스터 생성 로직
        Instantiate(monsterPrefab, position, Quaternion.identity);
    }

    void SpawnAirMonsterAtPosition(Vector3 position)
    {
        // 에어 몬스터 생성 로직
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