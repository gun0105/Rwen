using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour

{
    public GameObject objectToSpawn;
    public static bool isGroundSpawn;

    // Start is called before the first frame update
    void Start()
    {
        isGroundSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        isGroundSpawn = true;
    }
}
