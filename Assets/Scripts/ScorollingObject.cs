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
        if (!PlayerManager.isGameOver)//�÷��̾ ���� ���� ���¶�� speed�� �ӵ��� ��ŭ ���۵Ǿ� �ִ� ��, ������Ʈ ���� �쿡�� �·� �̵�
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
