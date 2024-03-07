using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public BossSpawner Spawner;

    public GroundSpawner Gspawner;

    public Spawn Mspawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Player�±׿� ����� ��� ���� ����
        {
            Spawner.SpawnObject();
            Gspawner.SpawnObject();
            Mspawner.SpawnerSpawn();
        }
    }
}
