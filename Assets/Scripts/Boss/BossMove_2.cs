using System.Collections;
using UnityEngine;

public class BossMove_2 : MonoBehaviour
{
    private bool isMoving = false;
    private bool isNormalAttackReady = true;
    private bool isStrongAttackReady = true;
    public BossHP2 hp;//test

    private const float normalAttackCooldown = 7f;
    private const float strongAttackCooldown = 12f;
    private const float moveTimeMin = 4f;
    private const float moveTimeMax = 8f;
    private const float moveSpeed = 8f;
    

    public GameObject normalAttackEffect;
    public GameObject strongAttackEffect;
    public GameObject AttackWarning;//test
    public Transform AttackWarningPoint;//test
    public float Attacklifetime = 0.5f;//test

    private Animator anim;
    private Vector3[] movePositions = { new Vector3(4.8f, -3.8f, -5f), new Vector3(4.8f, -0.8f, -5f) };

    GameObject c;

    private void Start()
    {
        anim = GetComponent<Animator>();
        hp = GetComponent<BossHP2>();//test
        // Start the boss behavior
        StartCoroutine(BossBehavior());
        // Apply initial cooldown for both normal and strong attacks
        StartCoroutine(StartNormalAttackCooldown());
        StartCoroutine(StartStrongAttackCooldown());
    }

    public void Update()
    {
        //느낌표 삭제
        Destroy(c, Attacklifetime);
    }

    private IEnumerator StartNormalAttackCooldown()
    {
        // Set the normal attack on cooldown at the beginning
        isNormalAttackReady = false;
        yield return new WaitForSeconds(normalAttackCooldown);
        isNormalAttackReady = true;
    }

    private IEnumerator StartStrongAttackCooldown()
    {
        // Set the strong attack on cooldown at the beginning
        isStrongAttackReady = false;
        yield return new WaitForSeconds(strongAttackCooldown);
        isStrongAttackReady = true;
    }

    private IEnumerator BossBehavior()
    {
        while (hp.health > 0)
        {
            // Random time interval for movement
            float moveTime = Random.Range(moveTimeMin, moveTimeMax);
            yield return new WaitForSeconds(moveTime);

            // Choose a random position to move to
            Vector3 targetPosition = movePositions[Random.Range(0, movePositions.Length)];

            // Start moving towards the target position
            StartCoroutine(MoveToPosition(targetPosition));

            // Wait for the movement to finish
            yield return new WaitForSeconds(moveTime);

            // Check if we can perform an attack
            if (isNormalAttackReady && isStrongAttackReady && hp.health > 0)
            {
                StartCoroutine(StrongAttack());
            }
            else if (isNormalAttackReady && hp.health > 0)
            {
                StartCoroutine(NormalAttack());
            }
            else if (isStrongAttackReady && hp.health > 0)
            {
                StartCoroutine(StrongAttack());
            }
        }
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        isMoving = true;
        while (transform.position != targetPosition && hp.health > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        Debug.Log("이동 완료");
        isMoving = false;
    }

    private IEnumerator NormalAttack()
    {
        // Check if the normal attack is ready to use
        if (!isNormalAttackReady)
        {
            Debug.Log("일반 공격은 아직 준비되지 않았습니다.");
            yield break; // Exit the function if the attack is not ready
        }

        // Set the normal attack on cooldown
        isNormalAttackReady = false;

        // Trigger the "Attack" animation state
        anim.SetTrigger("isAttack");

        //느낌표 생성
        c = Instantiate(AttackWarning, AttackWarningPoint.position, AttackWarningPoint.rotation);

        // Wait for the animation to finish
        yield return new WaitForSeconds(0.6f); // Adjust this time to match your attack animation duration

        // Instantiate the normal attack effect
        Instantiate(normalAttackEffect, transform.position, Quaternion.identity);

        Debug.Log("일반 공격 발동");

        // Wait for the cooldown to finish
        yield return new WaitForSeconds(normalAttackCooldown - 1.0f); // Subtract the time used for the animation

        // Reset the normal attack cooldown
        isNormalAttackReady = true;
    }

    private IEnumerator StrongAttack()
    {
        // Check if the strong attack is ready to use
        if (!isStrongAttackReady)
        {
            Debug.Log("강한 공격은 아직 준비되지 않았습니다.");
            yield break; // Exit the function if the attack is not ready
        }

        // Set the strong attack on cooldown
        isStrongAttackReady = false;

        // Trigger the "Attack" animation state
        anim.SetTrigger("isAttack");

        //느낌표 생성
        c = Instantiate(AttackWarning, AttackWarningPoint.position, AttackWarningPoint.rotation);

        // Wait for the animation to finish
        yield return new WaitForSeconds(0.6f); // Adjust this time to match your attack animation duration

        // Instantiate the strong attack effect
        Instantiate(strongAttackEffect, transform.position, Quaternion.identity);

        Debug.Log("강한 공격 발동");

        // Wait for the cooldown to finish
        yield return new WaitForSeconds(strongAttackCooldown - 1.0f); // Subtract the time used for the animation

        // Reset the strong attack cooldown
        isStrongAttackReady = true;
    }
}