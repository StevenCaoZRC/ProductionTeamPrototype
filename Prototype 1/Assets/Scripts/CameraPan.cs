using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    Camera m_camera;
    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main;
        offset = m_camera.transform.position - player.transform.position;
        offset.y += 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_camera.transform.position = player.transform.position + offset;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_camera.GetComponent<Animator>().SetTrigger("TargetEnd-Waterfall");
        }
    }
}