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
    Vector3 hitLocation;
    bool isRotating;
    bool ableToRotate;
    // Start is called before the first frame update
    void Start()
    {
        rayHitPoint = transform.forward;
        isRotating = false;
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
                    isRotating = true;
                    ableToRotate = true;
                    targetDir = hit.collider.transform.position - transform.position;
                    if(Mathf.Abs(targetDir.x) >= 0.9f || Mathf.Abs(targetDir.z) >= 0.9f) //If player is moving more than 1 square
                    {
                        rayHitPoint = hit.point;
                        hitLocation = hit.collider.transform.position;
                    }
                }      
            }
                
         }
        Movement();


    }
    void Movement()
    {
        Quaternion _targetDir = new Quaternion();

        if (isRotating == true && ableToRotate == true)
        {
            _targetDir = Quaternion.LookRotation(rayHitPoint - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetDir, speed * Time.deltaTime);
        }


        //Debug.Log(isRotating);
        if (transform.rotation.eulerAngles.y == _targetDir.eulerAngles.y)
        {
            isRotating = false;
            ableToRotate = false;
            agent.SetDestination(hitLocation);
            if (agent.transform.position == transform.position)
            {
                isRotating = true;
            }
        }
    }
}
