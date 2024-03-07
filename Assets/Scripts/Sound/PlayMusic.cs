using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public GameObject soundOn;//test
    public GameObject soundOff;//test
    bool isSound;

    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    public BgmType[] BGMList;

    private AudioSource BGM;
    private string NowBGMname = "";

    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.loop = true;
        PlayBGM(BGMList.Length > 0 ? BGMList[0].name : "");

        isSound = false;
        soundOff.SetActive(false);
        soundOn.SetActive(true);
    }

    public void PlayBGM(string name)
    {
        if (NowBGMname.Equals(name)) return;

        foreach (BgmType bgm in BGMList)
        {
            if (bgm.name.Equals(name))
            {
                BGM.clip = bgm.audio;
                BGM.Play();
                NowBGMname = name;
                return;
            }
        }
    }

    public void OnMusic()
    {
        BGM.Stop();
        isSound = true;
        toggleChange();
    }

    public void OffMusic()
    {
        BGM.Play();
        isSound = false;
        toggleChange();
    }

    public void toggleChange()
    {
        if (!isSound)
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
        else if (isSound)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
    }
}