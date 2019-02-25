using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera m_camera; //grabs the main camera
    public NavMeshAgent m_agent;
    public float m_speed = 5.0f;
    public float m_iceMoveTime = 2.0f;
    Vector3 m_targetDir;
    public Animator m_doubleCharaAnim;
    public Animator m_waterChildAnim;
    public Animator m_forestChildAnim;

    bool m_traversingLink = false;

    RaycastHit m_hit;
    Vector3 m_rayHitPoint;
    Vector3 m_hitLocation;

    // Start is called before the first frame update
    void Start()
    {
        m_rayHitPoint = transform.forward;
    }

    private void Update()
    {
        m_agent.angularSpeed = 0;

        if (m_agent.isOnOffMeshLink && !m_traversingLink)
        {
            StartCoroutine(WaterLink());

        }
    }

    // Update is called once per frame
    public void MovePlayer(RaycastHit _hit)
    {
        m_hit = _hit;

        MovementDestination();

        if (!m_traversingLink) //If not already on a link
        {
            StartCoroutine(Move());
        }
    }

    //Sets position if location is more than 1 square away 
    void MovementDestination()
    {
        m_targetDir = m_hit.collider.transform.position - transform.position;
        if (Mathf.Abs(m_targetDir.x) >= 0.9f || Mathf.Abs(m_targetDir.z) >= 0.9f) //If player is moving more than 1 square
        {
            m_rayHitPoint = m_hit.point;
            m_hitLocation = m_hit.collider.transform.position;
        }
        
        //---------Steven old code
        //
        //Quaternion _targetDir = new Quaternion();

        //if (isRotating == true && ableToRotate == true)
        //{
        //    _targetDir = Quaternion.LookRotation(rayHitPoint - transform.position);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetDir, speed * Time.deltaTime);
        //}


        ////Debug.Log(isRotating);
        //if (transform.rotation.eulerAngles.y == _targetDir.eulerAngles.y)
        //{
        //    isRotating = false;
        //    ableToRotate = false;
        //    agent.SetDestination(hitLocation);
        //    if (agent.transform.position == transform.position)
        //    {
        //        isRotating = true;
        //    }
        //}

    }

    //Move and rotate towards dest
    IEnumerator Move()
    {
        m_waterChildAnim.SetBool("WCWalk", true);
        m_forestChildAnim.SetBool("FCWalk", true);

        m_agent.SetDestination(m_hitLocation); // Start moving
        yield return new WaitForSeconds(0.05f); // compensating for remaining dist not updating immediately

        while (m_agent.remainingDistance != 0) // if agent is not at destination
        {
            //Cancel movement if destination is not reachable
            if (m_agent.remainingDistance == Mathf.Infinity || m_agent.pathPending
                || m_agent.pathStatus == NavMeshPathStatus.PathPartial)
            {
                m_waterChildAnim.SetBool("WCWalk", false);
                m_forestChildAnim.SetBool("FCWalk", false);

                yield break;
            }

            FacePosition(m_hitLocation); //Rotate chara to face location
            
            yield return null;
        }
        m_waterChildAnim.SetBool("WCWalk", false);
        m_forestChildAnim.SetBool("FCWalk", false);

    }

    //Used to start StraightAcross routine and to end the offmeshlink movement
    IEnumerator WaterLink()
    {
        m_doubleCharaAnim.SetTrigger("JumpIce");

        m_traversingLink = true;
        //MoveAcrossLink
        yield return StartCoroutine(StraightAcross());

        m_agent.CompleteOffMeshLink(); //Must complete manual offmeshlink to 'land' on other side
        m_traversingLink = false;

    }

    //Move across link in straight line
    IEnumerator StraightAcross()
    {
        m_agent.autoTraverseOffMeshLink = false;
        OffMeshLinkData data = m_agent.currentOffMeshLinkData;
        Vector3 endPos = data.endPos + Vector3.up * m_agent.baseOffset;
        if (m_agent.isOnOffMeshLink)
        {
            float seconds = Vector3.Distance(endPos, m_agent.transform.position) / m_iceMoveTime;
            while (m_agent.transform.position != endPos)
            {
                FacePosition(m_hitLocation);
                m_agent.transform.position = Vector3.MoveTowards(m_agent.transform.position, endPos, seconds * Time.deltaTime);
                yield return null;
            }
        }
        yield return null;
    }

    //Location to make the player face
    void FacePosition(Vector3 _pos)
    {
        Vector3 dir = (_pos - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0.0f, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * m_speed);
    }
}
