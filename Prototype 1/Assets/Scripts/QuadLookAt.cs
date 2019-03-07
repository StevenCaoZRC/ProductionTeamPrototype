using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadLookAt : MonoBehaviour
{
    private Camera m_cam;

    // Start is called before the first frame update
    void Start()
    {
        m_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + m_cam.transform.rotation * Vector3.forward,
            m_cam.transform.rotation * Vector3.up);
    }
}
