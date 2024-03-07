using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundoffSet : MonoBehaviour
{
    private MeshRenderer render;
    public float speed;

    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameOver)//�÷��̾ ����ִ� ���¶�� �޹���� ������ ó��
        {
            offset += Time.unscaledDeltaTime * speed;
            render.material.mainTextureOffset = new Vector2(offset, 0);
        }

        if (!PlayerManager.isGameOver && BossSpawner.isBossSpawn)
        {
            offset += Time.unscaledDeltaTime * speed * 2;
            render.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
