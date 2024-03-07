using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public GameObject MonsterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnerSpawn()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "3Stage" || currentScene == "4Stage")
            MonsterSpawn.SetActive(true);
    }
}
