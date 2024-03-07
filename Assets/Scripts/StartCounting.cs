using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCounting : MonoBehaviour
{
    public GameObject Pause;//일시정지 버튼
    public GameObject Stage_name;//스테이지 이름
    public GameObject Num_A;//1번
    public GameObject Num_B;//2번
    public GameObject Num_C;//3번
    public GameObject Num_GO;//시작 이미지
    private float startTime;

    public static bool isCount;

    private void Start()
    {
        isCount = false;
            Time.timeScale = 0f; //게임 정지
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
        Time.timeScale = 1f; // 게임 시작
        isCount = true;
    }

    IEnumerator LoadingEnd()
    {
        yield return new WaitForSeconds(0.5f);
        Num_GO.SetActive(false);
        Stage_name.SetActive(false);
    }

    /*private int Timer = 0;
    public GameObject Pause;//일시정지 버튼
    public GameObject Stage_name;//스테이지 이름
    public GameObject Num_A;//1번
    public GameObject Num_B;//2번
    public GameObject Num_C;//3번
    public GameObject Num_GO;//시작 이미지

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
        //게임 시작시 정지
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
                Time.timeScale = 1.0f; //게임시작
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

