using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCounting : MonoBehaviour
{
    public GameObject Pause;//�Ͻ����� ��ư
    public GameObject Stage_name;//�������� �̸�
    public GameObject Num_A;//1��
    public GameObject Num_B;//2��
    public GameObject Num_C;//3��
    public GameObject Num_GO;//���� �̹���
    private float startTime;

    public static bool isCount;

    private void Start()
    {
        isCount = false;
            Time.timeScale = 0f; //���� ����
            StartCoroutine(StartGame());
    }
    private IEnumerator StartGame()
    {
        Stage_name.SetActive(true);
        Pause.SetActive(false);
        startTime = Time.realtimeSinceStartup;
        Num_C.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        //yield return new WaitForSecondsRealtime(1);
        Num_C.SetActive(false);
        Num_B.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        Num_B.SetActive(false);
        Num_A.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        Num_A.SetActive(false);
        //Stage_name.SetActive(false);
        Num_GO.SetActive(true);
        Pause.SetActive(true);
        StartCoroutine(this.LoadingEnd());
        Time.timeScale = 1f; // ���� ����
        isCount = true;
    }

    IEnumerator LoadingEnd()
    {
        yield return new WaitForSeconds(0.5f);
        Num_GO.SetActive(false);
        Stage_name.SetActive(false);
    }

    /*private int Timer = 0;
    public GameObject Pause;//�Ͻ����� ��ư
    public GameObject Stage_name;//�������� �̸�
    public GameObject Num_A;//1��
    public GameObject Num_B;//2��
    public GameObject Num_C;//3��
    public GameObject Num_GO;//���� �̹���

    public static bool isCount;

    void Start()
    {
        Timer = 0;
        Time.timeScale = 0.0f;
        isCount = false;
        Pause.SetActive(false);
        Stage_name.SetActive(false);
        Num_A.SetActive(false);
        Num_B.SetActive(false);
        Num_C.SetActive(false);
        Num_GO.SetActive(false);
    }

    void Update()
    {
        //���� ���۽� ����
        //if (Timer == 0)
        //{
        //    Time.timeScale = 0.0f;
        //}
        if (Timer <= 1500)
        {
            Timer++;
            if (Timer > 1)
            {
                Stage_name.SetActive(true);
                Num_C.SetActive(true);
            }
            if (Timer > 500)
            {
                Num_C.SetActive(false);
                Num_B.SetActive(true);
            }
            if (Timer > 1000)
            {
                Num_B.SetActive(false);
                Num_A.SetActive(true);
            }
            if (Timer >= 1500)
            {
                Num_A.SetActive(false);
                Num_GO.SetActive(true);
                Pause.SetActive(true);
                StartCoroutine(this.LoadingEnd());
                Time.timeScale = 1.0f; //���ӽ���
                isCount = true;
            }
        }
    }
    IEnumerator LoadingEnd()
    {
        yield return new WaitForSeconds(0.5f);
        Num_GO.SetActive(false);
        Stage_name.SetActive(false);
    }*/
}

