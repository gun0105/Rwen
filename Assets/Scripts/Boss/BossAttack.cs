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
        Invoke("Destroy", lifetime);//맵 끝까지 총알이 날라가는 것을 방지하기 위해 Invoke를 사용하여 lifetime이 지난 후 총알 제거
    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(gameObject);
    }
}
