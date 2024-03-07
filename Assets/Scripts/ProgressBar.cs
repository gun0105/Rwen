using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform 컴포넌트
    public Transform goalPost; // 골대의 Transform 컴포넌트
    public Image progressBar; // 진행 게이지를 표시할 Image UI

    private float initialDistance; // 초기 거리
    private float maxDistance; // 최대 거리

    private void Start()
    {
        // 초기 거리와 최대 거리 계산
        initialDistance = Vector3.Distance(player.position, goalPost.position);
        maxDistance = initialDistance;
    }

    private void Update()
    {
        if (!PlayerManager.isGameOver)//이거를 빼면 차오르던 게이지가 다시 쭈욱 하고 떨어짐 고정 되는 것도 좋고 진행 게이지가 쭈욱 떨어지는 것도 웃길거같음.
        {
            // 플레이어와 골대 사이의 거리 계산
            float distance = Vector3.Distance(player.position, goalPost.position);

            // 진행 게이지 업데이트
            UpdateProgressBar(distance);
        }
    }

    private void UpdateProgressBar(float distance)
    {
        // 거리 비율 계산
        float distanceRatio = distance / initialDistance;

        // 진행 게이지 업데이트
        progressBar.fillAmount = 1 - distanceRatio; // 거리 비율의 보완을 위해 1에서 뺌
    }
}