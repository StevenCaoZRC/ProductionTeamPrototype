using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private  Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        //offset.y += 1.0f;
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
