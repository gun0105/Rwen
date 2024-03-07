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
            ProgressScreen.SetActive(false);//���� ��Ȳ�� ĵ���� off
            BossScreen.SetActive(true);//������ ������ ���� ���� HP�� ���ԵǾ��ִ� ĵ���� ����
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
