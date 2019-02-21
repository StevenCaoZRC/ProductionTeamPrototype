using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera m_camera; //grabs the main camera
    public NavMeshAgent agent;
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    Vector3 targetDir = hit.collider.transform.position - transform.position;
                    if(Mathf.Abs(targetDir.x) >= 0.9f || Mathf.Abs(targetDir.z) >= 0.9f) //If player is moving more than 1 square
                    {
                        //Debug.Log("target: x: " + targetDir.x + " y: " + targetDir.y + " z: " + targetDir.z);
                        Vector3 dir = Vector3.Slerp(transform.forward, hit.collider.transform.position, speed * Time.deltaTime);
                        transform.rotation = Quaternion.LookRotation(dir);
                        agent.SetDestination(hit.collider.gameObject.transform.position);

                    }
                }
            }
                
         }
    }
}
