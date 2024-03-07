using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesMove : MonoBehaviour
{
    public void Title()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main");
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        BossSpawner.isBossSpawn = false;
    }

    public void SelectStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StageSelect");
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        BossSpawner.isBossSpawn = false;
    }

    public void Howtoplay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HTP");
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        BossSpawner.isBossSpawn = false;
    }

    public void Howtoplay_2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HTP_2");
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        BossSpawner.isBossSpawn = false;
    }

    public void LoadStage1_Sel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage1_Select");
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        BossSpawner.isBossSpawn = false;
    }

    public void LoadStage2_Sel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage2_Select");
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        BossSpawner.isBossSpawn = false;
    }

    public void LoadStage3_Sel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage3_Select");
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        BossSpawner.isBossSpawn = false;
    }

    public void LoadStage4_Sel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage4_Select");
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        BossSpawner.isBossSpawn = false;
    }

    public void LoadStage1()
    {
        Time.timeScale = 1f;
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        SceneManager.LoadScene("1Stage");
        BossSpawner.isBossSpawn = false;
    }

    public void LoadStage2()
    {
        Time.timeScale = 1f;
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false; 
        SceneManager.LoadScene("2Stage");
        BossSpawner.isBossSpawn = false;
    }

    public void LoadStage3()
    {
        Time.timeScale = 1f;
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        SceneManager.LoadScene("3Stage");
        BossSpawner.isBossSpawn = false;
    }

    public void LoadStage4()
    {
        Time.timeScale = 1f;
        PauseOpen.isOpen = false;
        PlayerManager.isGameOver = false;
        SceneManager.LoadScene("4Stage");
        BossSpawner.isBossSpawn = false;
    }
}
