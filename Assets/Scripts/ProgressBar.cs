using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform ������Ʈ
    public Transform goalPost; // ����� Transform ������Ʈ
    public Image progressBar; // ���� �������� ǥ���� Image UI

    private float initialDistance; // �ʱ� �Ÿ�
    private float maxDistance; // �ִ� �Ÿ�

    private void Start()
    {
        // �ʱ� �Ÿ��� �ִ� �Ÿ� ���
        initialDistance = Vector3.Distance(player.position, goalPost.position);
        maxDistance = initialDistance;
    }

    private void Update()
    {
        if (!PlayerManager.isGameOver)//�̰Ÿ� ���� �������� �������� �ٽ� �޿� �ϰ� ������ ���� �Ǵ� �͵� ���� ���� �������� �޿� �������� �͵� ����Ű���.
        {
            // �÷��̾�� ��� ������ �Ÿ� ���
            float distance = Vector3.Distance(player.position, goalPost.position);

            // ���� ������ ������Ʈ
            UpdateProgressBar(distance);
        }
    }

    private void UpdateProgressBar(float distance)
    {
        // �Ÿ� ���� ���
        float distanceRatio = distance / initialDistance;

        // ���� ������ ������Ʈ
        progressBar.fillAmount = 1 - distanceRatio; // �Ÿ� ������ ������ ���� 1���� ��
    }
}