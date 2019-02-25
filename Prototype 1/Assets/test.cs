using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Vector3 pos;    
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 A = new Vector3(0, 0, 0);
        Vector3 B = new Vector3(-2f, 5.514f, 0.51f);

        if (Input.GetMouseButton(0))
        {
            pos = B;
        }
        if (Input.GetMouseButton(1))
        {
            pos = A;
        }

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
