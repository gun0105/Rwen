using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;//플레이어 사망 체크
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);//플레이어 사망 시 사망 UI 등장
        }
    }
}
