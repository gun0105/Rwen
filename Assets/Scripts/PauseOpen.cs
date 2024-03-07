using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOpen : MonoBehaviour
{
    public GameObject open;
    public static bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
                closePause();
            else
                openPause();
        }
    }

    public void openPause()
    {
        open.SetActive(true);
        isOpen = true;
        Time.timeScale = 0.0f;
    }
    public void closePause()
    {
        open.SetActive(false);
        isOpen = false;
        Time.timeScale = 1.0f;
    }
}
