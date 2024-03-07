using System.Collections;
using UnityEngine;

public class BossMove_3 : MonoBehaviour
{
    private bool isMoving = false;
    private bool isNormalAttackReady = true;
    private bool isStrongAttackReady = true;
    public BossHP3 hp;//test

    private const float normalAttackCooldown = 5f;
    private const float strongAttackCooldown = 10f;
    private const float moveTimeMin = 3f;
    private const float moveTimeMax = 6f;
    private const float moveSpeed = 8f;


    public GameObject normalAttackEffect;
    public GameObject strongAttackEffect;

    public GameObject AttackWarning;//test
    public Transform AttackWarningPoint;//test
    public float Attacklifetime = 0.5f;//test

    public Transform AttackPoint;//test_12.01

    private Animator anim;
    private Vector3[] movePositions = { new Vector3(4.8f, -4.4f, -5f), new Vector3(4.8f, -1.4f, -5f) };

    GameObject c;

    private void Start()
    {
        anim = GetComponent<Animator>();
        hp = GetComponent<BossHP3>();
        // 보스 이동 코루틴
        StartCoroutine(BossBehavior());
        // 보스 공격 / 강공격 코루틴
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
        // 기본 공격 쿨타임
        isNormalAttackReady = false;
        yield return new WaitForSeconds(normalAttackCooldown);
        isNormalAttackReady = true;
    }

    private IEnumerator StartStrongAttackCooldown()
    {
        // 강 공격 쿨타임
        isStrongAttackReady = false;
        yield return new WaitForSeconds(strongAttackCooldown);
        isStrongAttackReady = true;
    }

    private IEnumerator BossBehavior()
    {
        while (hp.health > 0)
        {
            // 움직임을 위한 moveTimeMin Max 랜덤 설정 후 moveTime만큼 대기
            float moveTime = Random.Range(moveTimeMin, moveTimeMax);
            yield return new WaitForSeconds(moveTime);

            // 이동할 위치 생성
            Vector3 targetPosition = movePositions[Random.Range(0, movePositions.Length)];

            // 생성된 위치로 이동
            StartCoroutine(MoveToPosition(targetPosition));

            // 이동이 끝난 후 다음 moveTime까지 대기
            yield return new WaitForSeconds(moveTime);

            // 공격/강공격의 쿨타임이 돌아서 공격이 가능한지 확인 후 공격
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
        // 준비 안된 상태
        if (!isNormalAttackReady)
        {
            Debug.Log("일반 공격은 아직 준비되지 않았습니다.");
            yield break; // Exit the function if the attack is not ready
        }

        // 쿨타임 일반공격 설정
        isNormalAttackReady = false;

        // 공격 애니메이션 재생
        anim.SetTrigger("isAttack");

        //느낌표 생성
        c = Instantiate(AttackWarning, AttackWarningPoint.position, AttackWarningPoint.rotation);

        // 애니메이션이 끝날때까지 대기
        yield return new WaitForSeconds(0.6f);

        // 공격 프리팹 생성
        Instantiate(normalAttackEffect, AttackPoint.position, Quaternion.identity);

        Debug.Log("일반 공격 발동");

        // 쿨타임이 다시 찰때까지 대기
        yield return new WaitForSeconds(normalAttackCooldown - 1.0f);

        // 쿨타임 초기화
        isNormalAttackReady = true;
    }

    private IEnumerator StrongAttack()
    {

        if (!isStrongAttackReady)
        {
            Debug.Log("강한 공격은 아직 준비되지 않았습니다.");
            yield break;
        }


        isStrongAttackReady = false;

        anim.SetTrigger("isAttack");

        //느낌표 생성
        c = Instantiate(AttackWarning, AttackWarningPoint.position, AttackWarningPoint.rotation);

        yield return new WaitForSeconds(0.6f);

        Instantiate(strongAttackEffect, AttackPoint.position, Quaternion.identity);

        Debug.Log("강한 공격 발동");

        yield return new WaitForSeconds(strongAttackCooldown - 1.0f);

        isStrongAttackReady = true;
    }
}