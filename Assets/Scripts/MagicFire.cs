using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.EventSystems;//test

public class MagicFire : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

    //public static int maxAmmo = 20; // 최대 총알 수
    //public static int currentAmmo; // 현재 총알 수
    //public float reloadTime = 3.0f; // 장전 시간 (초)
    //public bool isReloading = false; // 현재 장전 중인지 여부
    public KeyCode fireKey = KeyCode.Z; // 발사 키

    //public Text ammoText;

    void Start()
    {
        //currentAmmo = maxAmmo;
        //UpdateAmmoText();
    }
    void Update()
    {
        //if (isReloading) // 장전 중이면
        //    return; // 발사하지 않음

        if (Input.GetKeyDown(fireKey) && /*currentAmmo > 0 &&*/ !PlayerManager.isGameOver && !PauseOpen.isOpen && StartCounting.isCount) // 발사 키를 누르고 총알이 남아 있으면
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Shoot(); // 발사
            }
        }
        /*else if (Input.GetKeyDown(fireKey) && currentAmmo == 0 && !PlayerManager.isGameOver && !PauseOpen.isOpen) // 발사 키를 누르고 총알이 없으면
        {
            StartCoroutine(Reload()); // 장전 시작
        }*/
    }

    void Shoot()
    {
        //currentAmmo--; // 총알 수 감소

        // 발사하는 코드 작성
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

        /*if (currentAmmo == 0) // 총알이 다 떨어졌으면
        {
            StartCoroutine(Reload()); // 장전 시작
        }

        UpdateAmmoText();*/
    }

    /*IEnumerator Reload()
    {
        isReloading = true; // 장전 중으로 설정

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime); // 장전 시간만큼 기다림

        currentAmmo = maxAmmo; // 총알 수 초기화
        isReloading = false; // 장전 완료

        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        
            ammoText.text = currentAmmo.ToString();
    }*/
}
