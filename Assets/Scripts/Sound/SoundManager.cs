using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;

    private void Awake()
    {
        var soundsManagers = FindObjectsOfType<SoundManager>();

        if (soundsManagers.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bgm.Play();
    }

    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "1Stage" || sceneName == "2Stage" || sceneName == "3Stage" || sceneName == "4Stage")
        {
            Destroy(gameObject);
        }
    }
}