using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private  Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //offset = transform.position - player.transform.position;

        transform.position = new Vector3(player.transform.position.x -25.0f, transform.position.y, player.transform.position.z -25f);
        offset = transform.position - player.transform.position;

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
