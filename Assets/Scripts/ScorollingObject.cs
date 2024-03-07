using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorollingObject : MonoBehaviour
{
    public float speed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameOver)//플레이어가 죽지 않은 상태라면 speed의 속도값 만큼 제작되어 있는 맵, 오브젝트 들이 우에서 좌로 이동
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
