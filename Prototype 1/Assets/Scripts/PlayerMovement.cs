using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera m_camera; //grabs the main camera
    public NavMeshAgent agent;
    public float speed = 2.0f;
    Vector3 targetDir;
    RaycastHit hit;
    Vector3 rayHitPoint;
    // Start is called before the first frame update
    void Start()
    {
        rayHitPoint = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
           
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    targetDir = hit.collider.transform.position - transform.position;
                    if(Mathf.Abs(targetDir.x) >= 0.9f || Mathf.Abs(targetDir.z) >= 0.9f) //If player is moving more than 1 square
                    {
                        rayHitPoint = hit.point;


                    }

            

                }
               
                    
            }
                
         }
        Debug.Log("target: x: " + targetDir.x + " y: " + targetDir.y + " z: " + targetDir.z);

        Quaternion _targetDir = Quaternion.LookRotation(rayHitPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetDir, speed * Time.deltaTime);
       
           

       agent.SetDestination(hit.collider.gameObject.transform.position);
    }       

}
