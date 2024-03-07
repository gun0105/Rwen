using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.right * speed;
        Invoke("Destroy", lifetime);//�� ������ �Ѿ��� ���󰡴� ���� �����ϱ� ���� Invoke�� ����Ͽ� lifetime�� ���� �� �Ѿ� ����
    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(gameObject);
    }
}
