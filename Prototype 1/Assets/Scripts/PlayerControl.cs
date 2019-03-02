using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    [Header("Character references")]
    public Player m_childOne;
    public Player m_childTwo;
    public Animator m_doubleCharaAnimator;
    public PlayerMovement m_movement;
    public LayerMask m_layerMask;
    public bool m_waterLeading = true;

    [Header("Private //just for checking")]
    [SerializeField]
    private bool Climbed = false;
    
    private void Start()
    {
        //Depending on who is leading when script starts up, set character as lead

        //Get From level read script for whoever leads first
        m_childOne.GetComponent<Player>().Reset();
        m_childTwo.GetComponent<Player>().Reset();

        if (m_waterLeading)
        {
            m_childOne.gameObject.SetActive(true);
            m_childTwo.gameObject.SetActive(false);
        }
        else
        {
            m_childOne.gameObject.SetActive(false);
            m_childTwo.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(LayerMask.LayerToName(hit.collider.transform.gameObject.layer));
                if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")
                    || hit.collider.gameObject.layer == LayerMask.NameToLayer("VineBlock"))
                {
                    m_movement.MovePlayer(hit);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.transform.gameObject.name);

                if (hit.transform.gameObject.tag == "Fire" && m_waterLeading)// && hit.transform.gameObject.transform.forward == transform.position)
                {
                    //Put out fire
                    m_movement.MoveToTarget(hit.transform.gameObject);
                    
                    m_childOne.SpellOne(hit.transform.gameObject);

                }

                if (hit.transform.gameObject.tag == "WaterBlock" && m_waterLeading)// && hit.transform.gameObject.transform.forward == transform.position)
                {
                    //Create Ice
                    m_movement.MoveToTarget(hit.transform.gameObject);

                    m_childOne.SpellTwo(hit.transform.gameObject);
                }

                if (hit.transform.gameObject.tag == "VineBlock" && !m_waterLeading && !Climbed)
                {
                   
                    m_childTwo.SpellOne(hit.transform.gameObject);
                    Climbed = true;
                    //m_movement.MoveToTarget(hit.transform.gameObject);

                }

                if (hit.transform.gameObject.tag == "VineGround" && !m_waterLeading && Climbed)
                {
                    //m_movement.MoveToTarget(hit.transform.gameObject);
                    m_childTwo.SpellOne(hit.transform.gameObject);
                    Climbed = false;
                   
                }
            }
        }
        //Single Mouse Right click
        if (Input.GetMouseButtonDown(2))
        {
            SwitchCharaPos();
        }
    }

    //Checks who is leading and switches them with the backup chara
    //Handles animation
    public void SwitchCharaPos()
    {

        if (m_waterLeading)
        {
            m_childOne.gameObject.SetActive(false);
            m_childTwo.gameObject.SetActive(true);
            m_childTwo.PlaySwitchAnim();

            //Play animations
            m_waterLeading = false;
        }
        else
        {
            m_childOne.gameObject.SetActive(true);
            m_childTwo.gameObject.SetActive(false);

            m_childOne.PlaySwitchAnim();

            //Play animations
            m_waterLeading = true;
        }
        Debug.Log("Child leading: " + ((m_waterLeading) ? m_childOne.tag : m_childTwo.tag));
    }

    public void SetIsLeading(bool _leading)
    {
        m_waterLeading = _leading;
    }

    public bool GetIsLeading()
    {
        return m_waterLeading;
    }
}
