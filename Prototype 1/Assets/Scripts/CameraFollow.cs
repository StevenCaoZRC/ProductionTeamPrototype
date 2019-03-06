using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset = new Vector3(-26.0f, 21.5f, -26.0f);

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().fieldOfView = 15;
        player = GameObject.FindGameObjectWithTag("Player");
        offset = new Vector3(-26.0f, 21.5f, -26.0f);
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CameraPan());
        }
    }

    IEnumerator CameraPan()
    {
        GetComponent<Animator>().SetTrigger("TargetEnd-Waterfall");
        yield return new WaitForSeconds(6.0f);
        GetComponent<Animator>().enabled = false;
    }
}
