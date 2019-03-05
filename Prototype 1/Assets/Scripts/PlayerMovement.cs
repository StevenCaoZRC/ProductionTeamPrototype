using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera m_camera; //grabs the main camera
    public NavMeshAgent m_agent;
    public float m_speed = 3.0f;
    public float m_iceMoveTime = 2.0f;
    Vector3 m_targetDir;
    public Animator m_waterChildAnim;
    public Animator m_forestChildAnim;

    bool m_traversingLink = false;
    bool m_targeting = false;
    bool m_isMoving = false;
    bool m_isTargetMove = false;

    RaycastHit m_hit;
    Vector3 m_toLookAt;
    Vector3 m_hitLocation;
    Quaternion m_intendedRotation;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if(m_agent.isOnOffMeshLink)
        {
            Debug.Log("WHERE IT STORT");

        }
        if (m_agent.isOnOffMeshLink && !m_traversingLink)
        {
            StartWalkAnim();

            StartCoroutine(WaterLink());
        }
        if (!m_agent.isOnOffMeshLink && !m_traversingLink)
        {
            if (m_isMoving)
            {

                StartWalkAnim();
            }
            else
            {
                EndWalkAnim();
                if(m_isTargetMove)
                    FacePosition(m_hitLocation);
            }
        }
    }

    public void Rotate(GameObject _object)
    {
        m_isTargetMove = true;
        m_targetDir = _object.transform.position - transform.position;

        //If player is clicking on a pos more than 1 square && clicking a higher square
        if ((Mathf.Abs(m_targetDir.x) >= 0.9f || Mathf.Abs(m_targetDir.z) >= 0.9f))
        {
            m_hitLocation = new Vector3(_object.transform.position.x, transform.position.y, _object.transform.position.z);
        }
    }

    // Update is called once per frame
    public void MovePlayer(RaycastHit _hit)
    {
        m_hit = _hit;
        m_isTargetMove = false;
        MovementDestination();
    }

    public void MoveToTarget(GameObject _object)
    {
        m_isTargetMove = true;
        m_targetDir = _object.transform.position - transform.position;

        //If player is clicking on a pos more than 1 square && clicking a higher square
        if ((Mathf.Abs(m_targetDir.x) >= 0.9f || Mathf.Abs(m_targetDir.z) >= 0.9f))
        {
            m_hitLocation = new Vector3(_object.transform.position.x, transform.position.y, _object.transform.position.z);

            if (!m_traversingLink && m_agent != null) //If not already on a link
            {
                m_targeting = true;
                m_agent.stoppingDistance = 1.5f;
                StartCoroutine(Move());
            }
        }
    }

    //Sets position if location is more than 1 square away 
    void MovementDestination()
    {
        m_targetDir = m_hit.collider.transform.position - transform.position;

        //If player is clicking on a pos more than 1 square && clicking a higher square
        if ((Mathf.Abs(m_targetDir.x) >= 0.9f || Mathf.Abs(m_targetDir.z) >= 0.9f ) )// && (m_targetDir.y <= 1.5 && m_targetDir.y >= -1.5f)) 
        {
            m_hitLocation = m_hit.collider.transform.position;
            m_agent.stoppingDistance = 0.0f;

            if (!m_traversingLink && m_agent != null) //If not already on a link
            {
                StartCoroutine(Move());
            }
        }
    }

    public bool GetIsMoving()
    {
        return m_isMoving;
    }

    //Move and rotate towards dest
    IEnumerator Move()
    {
        m_isMoving = true;

        m_agent.SetDestination(m_hitLocation); // Start moving

        yield return new WaitForSeconds(0.05f); // compensating for remaining dist not updating immediately

        while ((m_agent.remainingDistance != 0 && m_agent.enabled)) // if agent is not at destination
        {
            StartWalkAnim();
            //Cancel movement if destination is not reachable
            if (m_agent.pathPending || (m_agent.remainingDistance < m_agent.stoppingDistance && m_targeting))
            {
                m_targeting = false;
                m_isMoving = false;
                yield break;
            }

            //Keep moving if avoiding obstacles 
            if(m_agent.remainingDistance == Mathf.Infinity)
            {
                m_isMoving = true;
            }

            FacePosition(m_hitLocation); //Rotate chara to face location
            yield return null;
        }
        m_targeting = false;
        m_isMoving = false;
    }


    //Used to start StraightAcross routine and to end the offmeshlink movement
    IEnumerator WaterLink()
    {
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

    void StartWalkAnim()
    {
        if (m_waterChildAnim.gameObject.activeSelf)
            m_waterChildAnim.SetBool("WCWalk", true);

        if (m_forestChildAnim.gameObject.activeSelf)
            m_forestChildAnim.SetBool("FCWalk", true);
    }

    void EndWalkAnim()
    {
        if (m_waterChildAnim.gameObject.activeSelf)
            m_waterChildAnim.SetBool("WCWalk", false);

        if (m_forestChildAnim.gameObject.activeSelf)
            m_forestChildAnim.SetBool("FCWalk", false);
    }

}
