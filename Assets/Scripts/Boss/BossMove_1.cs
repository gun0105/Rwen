using System.Collections;
using UnityEngine;

public class BossMove_1 : MonoBehaviour
{
    private bool isMoving = false;
    private bool isNormalAttackReady = true;
    private bool isStrongAttackReady = true;
    public BossHP hp;//test

    private const float normalAttackCooldown = 7f;
    private const float strongAttackCooldown = 15f;
    private const float moveTimeMin = 5f;
    private const float moveTimeMax = 10f;
    private const float moveSpeed = 8f;
    

    public GameObject normalAttackEffect;
    public GameObject strongAttackEffect;
    public GameObject AttackWarning;//test
    public Transform AttackWarningPoint;//test
    public float Attacklifetime = 0.5f;//test

    private Animator anim;
    private Vector3[] movePositions = { new Vector3(4.8f, -3.8f, -7f), new Vector3(4.8f, -0.8f, -7f) };

    GameObject c;

    private void Start()
    {
        anim = GetComponent<Animator>();
        hp = GetComponent<BossHP>();
        // ���� �̵� �ڷ�ƾ
        StartCoroutine(BossBehavior());
        // ���� ����/ ������ �ڷ�ƾ
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
        yield return new WaitForSeconds(1.0f);

        // ���� ������ ����
        Instantiate(normalAttackEffect, transform.position, Quaternion.identity);

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


        yield return new WaitForSeconds(1.0f);


        Instantiate(strongAttackEffect, transform.position, Quaternion.identity);

        Debug.Log("���� ���� �ߵ�");


        yield return new WaitForSeconds(strongAttackCooldown - 1.0f); 


        isStrongAttackReady = true;
    }
}