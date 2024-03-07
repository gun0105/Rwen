using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject Destroyer;
    // Start is called before the first frame update
    void Start()
    {
        Destroyer = GameObject.Find("Destroyer");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Destroyer.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
