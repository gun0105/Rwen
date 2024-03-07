using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour
{
    [Header("Attack")]
    public Image attackImage;
    public float cooldown_a = 2f;
    //public int maxAmmo = 20;
    public int currentAmmo;
    bool isAttackDown = false;
    public KeyCode attack;

    [Header("Shield")]
    public Image shieldImage;
    public float cooldown_s = 15f;
    bool isShieldDown = false;
    public KeyCode shield;

    [Header("Lightning")]
    public Image lightningImage;
    public float cooldown_l = 20f;
    bool isLightningDown = false;
    public KeyCode lightning;

    // Start is called before the first frame update
    void Start()
    {
        //currentAmmo = maxAmmo;
        //currentAmmo = MagicFire.maxAmmo;
        shieldImage.fillAmount = 0;
        lightningImage.fillAmount = 0;
        attackImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Skill_S();
        Skill_L();
        //Attack();
        //currentAmmo = MagicFire.currentAmmo;
    }

    void Skill_S()
    {
        if (Input.GetKey(shield) && !isShieldDown && !PlayerManager.isGameOver && !PauseOpen.isOpen && StartCounting.isCount)
        {
            isShieldDown = true;
            shieldImage.fillAmount = 1;
        }

        if (isShieldDown)
        {
            shieldImage.fillAmount -= 1 / cooldown_s * Time.deltaTime;
            if (shieldImage.fillAmount <= 0)
            {
                shieldImage.fillAmount = 0;
                isShieldDown = false;
            }
        }
    }

    void Skill_L()
    {
        if (Input.GetKey(lightning) && !isLightningDown && !PlayerManager.isGameOver && !PauseOpen.isOpen && StartCounting.isCount)
        {
            isLightningDown = true;
            lightningImage.fillAmount = 1;
        }

        if (isLightningDown)
        {
            lightningImage.fillAmount -= 1 / cooldown_l * Time.deltaTime;
            if (lightningImage.fillAmount <= 0)
            {
                lightningImage.fillAmount = 0;
                isLightningDown = false;
            }
        }
    }

    /*void Attack()
    {
        if (currentAmmo <= 0 && !isAttackDown)
        {
            isAttackDown = true;
            attackImage.fillAmount = 1;
        }

        if (isAttackDown)
        {
            attackImage.fillAmount -= 1 / cooldown_a * Time.deltaTime;
            if (attackImage.fillAmount <= 0)
            {
                attackImage.fillAmount = 0;
                isAttackDown = false;
            }
        }
    }*/
}
