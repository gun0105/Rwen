using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    public static bool activeShield;
    private float cooldownTime = 15f; // ��Ÿ�� �ð� (��)
    private float shieldDuration = 3f; // �� ���� �ð� (��)
    private float lastSkillTime; // ���������� ��ų�� ����� �ð�

    // Start is called before the first frame update
    void Start()
    {
        lastSkillTime = -cooldownTime;
        activeShield = false;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && Time.time - lastSkillTime >= cooldownTime && !PlayerManager.isGameOver && !PauseOpen.isOpen && StartCounting.isCount)
        {
            StartShieldSkill();
        }

        if (activeShield && Time.time - lastSkillTime >= shieldDuration)
        {
            EndShieldSkill();
        }
    }

    private void StartShieldSkill()
    {
        shield.SetActive(true);
        activeShield = true;
        lastSkillTime = Time.time;
    }

    private void EndShieldSkill()
    {
        Invoke("activefalse", 0.65f);
        activeShield = false;
    }

    void activefalse()
    {
        shield.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activeShield)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("obstacle") || collision.CompareTag("Normalattack") || collision.CompareTag("Strongattack"))
            {
                EndShieldSkill(); // �� �Ǵ� ��ֹ� �Ǵ� ���ݰ� �浹�ϸ� ���� ����
            }
        }
    }
}