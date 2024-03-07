using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_Anim : MonoBehaviour
{
    Animator anim;
    public float cooldown_s = 15f;
    private bool canPlayAnimation = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && canPlayAnimation && !PlayerManager.isGameOver && !PauseOpen.isOpen && StartCounting.isCount)
        {
            PlayAnimation();
            canPlayAnimation = false;
            StartCoroutine(ResetAnimationCooldown());
        }
    }

    void PlayAnimation()
    {
        anim.SetTrigger("isSkill");
    }

    IEnumerator ResetAnimationCooldown()
    {
        yield return new WaitForSeconds(cooldown_s);
        canPlayAnimation = true;
    }
}