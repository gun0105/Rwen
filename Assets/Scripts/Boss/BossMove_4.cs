using System.Collections;
using UnityEngine;

public class BossMove_4 : MonoBehaviour
{
    private bool isMoving = false;
    private bool isNormalAttackReady = true;
    private bool isStrongAttackReady = true;
    public BossHP4 hp;//test

    private const float normalAttackCooldown = 3.5f;
    private const float strongAttackCooldown = 7f;
    private const float moveTimeMin = 2f;
    private const float moveTimeMax = 5f;
    private const float moveSpeed = 8f;


    public GameObject normalAttackEffect;
    public GameObject strongAttackEffect;

    public GameObject AttackWarning;//test
    public Transform AttackWarningPoint;//test
    public float Attacklifetime = 0.5f;//test

    public Transform AttackPoint;//test_12.01

    private Animator anim;
    private Vector3[] movePositions = { new Vector3(5.36f, -3.8f, -5f), new Vector3(5.36f, -0.8f, -5f) };

    GameObject c;

    private void Start()
    {
        anim = GetComponent<Animator>();
        hp = GetComponent<BossHP4>();
        // ���� �̵� �ڷ�ƾ
        StartCoroutine(BossBehavior());
        // ���� ���� / ������ �ڷ�ƾ
        StartCoroutine(StartNormalAttackCooldown());
        StartCoroutine(StartStrongAttackCooldown());
    }

    public void Update()
    {
        //����ǥ ����
        Destroy(c, Attacklifetime);
    }

    private IEnumerator StartNormalAttackCooldown()
    {
        // �⺻ ���� ��Ÿ��
        isNormalAttackReady = false;
        yield return new WaitForSeconds(normalAttackCooldown);
        isNormalAttackReady = true;
    }

    private IEnumerator StartStrongAttackCooldown()
    {
        // �� ���� ��Ÿ��
        isStrongAttackReady = false;
        yield return new WaitForSeconds(strongAttackCooldown);
        isStrongAttackReady = true;
    }

    private IEnumerator BossBehavior()
    {
        while (hp.health > 0)
        {
            // �������� ���� moveTimeMin Max ���� ���� �� moveTime��ŭ ���
            float moveTime = Random.Range(moveTimeMin, moveTimeMax);
            yield return new WaitForSeconds(moveTime);

            // �̵��� ��ġ ����
            Vector3 targetPosition = movePositions[Random.Range(0, movePositions.Length)];

            // ������ ��ġ�� �̵�
            StartCoroutine(MoveToPosition(targetPosition));

            // �̵��� ���� �� ���� moveTime���� ���
            yield return new WaitForSeconds(moveTime);

            // ����/�������� ��Ÿ���� ���Ƽ� ������ �������� Ȯ�� �� ����
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
        Debug.Log("�̵� �Ϸ�");
        isMoving = false;
    }

    private IEnumerator NormalAttack()
    {
        // �غ� �ȵ� ����
        if (!isNormalAttackReady)
        {
            Debug.Log("�Ϲ� ������ ���� �غ���� �ʾҽ��ϴ�.");
            yield break; // Exit the function if the attack is not ready
        }

        // ��Ÿ�� �Ϲݰ��� ����
        isNormalAttackReady = false;

        // ���� �ִϸ��̼� ���
        anim.SetTrigger("isAttack");

        //����ǥ ����
        c = Instantiate(AttackWarning, AttackWarningPoint.position, AttackWarningPoint.rotation);

        // �ִϸ��̼��� ���������� ���
        yield return new WaitForSeconds(0.6f);

        // ���� ������ ����
        Instantiate(normalAttackEffect, AttackPoint.position, Quaternion.identity);

        Debug.Log("�Ϲ� ���� �ߵ�");

        // ��Ÿ���� �ٽ� �������� ���
        yield return new WaitForSeconds(normalAttackCooldown - 1.0f);

        // ��Ÿ�� �ʱ�ȭ
        isNormalAttackReady = true;
    }

    private IEnumerator StrongAttack()
    {

        if (!isStrongAttackReady)
        {
            Debug.Log("���� ������ ���� �غ���� �ʾҽ��ϴ�.");
            yield break;
        }


        isStrongAttackReady = false;

        anim.SetTrigger("isAttack");

        //����ǥ ����
        c = Instantiate(AttackWarning, AttackWarningPoint.position, AttackWarningPoint.rotation);

        yield return new WaitForSeconds(0.6f);

        Instantiate(strongAttackEffect, AttackPoint.position, Quaternion.identity);

        Debug.Log("���� ���� �ߵ�");

        yield return new WaitForSeconds(strongAttackCooldown - 1.0f);

        isStrongAttackReady = true;
    }
}