using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.EventSystems;//test

public class MagicFire : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

    //public static int maxAmmo = 20; // �ִ� �Ѿ� ��
    //public static int currentAmmo; // ���� �Ѿ� ��
    //public float reloadTime = 3.0f; // ���� �ð� (��)
    //public bool isReloading = false; // ���� ���� ������ ����
    public KeyCode fireKey = KeyCode.Z; // �߻� Ű

    //public Text ammoText;

    void Start()
    {
        //currentAmmo = maxAmmo;
        //UpdateAmmoText();
    }
    void Update()
    {
        //if (isReloading) // ���� ���̸�
        //    return; // �߻����� ����

        if (Input.GetKeyDown(fireKey) && /*currentAmmo > 0 &&*/ !PlayerManager.isGameOver && !PauseOpen.isOpen && StartCounting.isCount) // �߻� Ű�� ������ �Ѿ��� ���� ������
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Shoot(); // �߻�
            }
        }
        /*else if (Input.GetKeyDown(fireKey) && currentAmmo == 0 && !PlayerManager.isGameOver && !PauseOpen.isOpen) // �߻� Ű�� ������ �Ѿ��� ������
        {
            StartCoroutine(Reload()); // ���� ����
        }*/
    }

    void Shoot()
    {
        //currentAmmo--; // �Ѿ� �� ����

        // �߻��ϴ� �ڵ� �ۼ�
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

        /*if (currentAmmo == 0) // �Ѿ��� �� ����������
        {
            StartCoroutine(Reload()); // ���� ����
        }

        UpdateAmmoText();*/
    }

    /*IEnumerator Reload()
    {
        isReloading = true; // ���� ������ ����

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime); // ���� �ð���ŭ ��ٸ�

        currentAmmo = maxAmmo; // �Ѿ� �� �ʱ�ȭ
        isReloading = false; // ���� �Ϸ�

        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        
            ammoText.text = currentAmmo.ToString();
    }*/
}
