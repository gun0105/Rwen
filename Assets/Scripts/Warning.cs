using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject WarningScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        WarningScreen.SetActive(true);
        Invoke("Spawndie",2.5f);
    }
    public void Spawndie()
    {
        WarningScreen.SetActive(false);
    }
}
