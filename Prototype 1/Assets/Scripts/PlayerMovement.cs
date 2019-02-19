using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera camera; //grabs the main camera
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    Vector3 targetDir = hit.collider.transform.position - transform.position;
                    
                    Vector3 dir = Vector3.RotateTowards(transform.forward, targetDir, 20 * Time.deltaTime, 0.0f);
                    Debug.DrawRay(transform.position,dir,Color.red, 50);
                    transform.rotation = Quaternion.LookRotation(dir);
                    agent.SetDestination(hit.collider.gameObject.transform.position); 
                }
            }
                
         }
    }
}
