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
        isGameOver = false;//�÷��̾� ��� üũ
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);//�÷��̾� ��� �� ��� UI ����
        }
    }
}
