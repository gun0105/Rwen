using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Bossmonster;
    //public GameObject objectToSpawn;
    public static bool isBossSpawn;
    public GameObject BossScreen;
    public static bool isProgressOut;
    public GameObject ProgressScreen;

    // Start is called before the first frame update
    void Start()
    {
        isBossSpawn = false;
        isProgressOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBossSpawn && !isProgressOut)
        {
            ProgressScreen.SetActive(false);//진행 상황바 캔버스 off
            BossScreen.SetActive(true);//보스의 출현을 따져 보스 HP가 포함되어있는 캔버스 등장
        }
    }

    public void SpawnObject()
    {
        //Instantiate(objectToSpawn, transform.position, transform.rotation);
        Bossmonster.SetActive(true);
        isBossSpawn = true;
        isProgressOut = false;
    }
}
