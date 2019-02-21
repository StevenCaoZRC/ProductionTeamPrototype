using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    [Header("Character references")]
    public Player m_childOne;
    public Player m_childTwo;
    public GameObject Vine1;
    public GameObject Vine2;
    [Header("Target Positions For Characters to stay at (Idle)")]
    public GameObject m_selectedPos;
    public GameObject[] m_backupPos;

    [Header("Private //just for checking")]
    [SerializeField]
    private bool m_childOneLeading = true;

    private void Start()
    {
        Vine1.SetActive(false);
        Vine2.SetActive(false);
        //Depending on who is leading when script starts up, set character as lead
        if (m_childOneLeading)
            SwitchPos(m_childTwo, m_childOne);
        else
            SwitchPos(m_childOne, m_childTwo);
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
                Debug.Log(hit.transform.gameObject.name);

                if (hit.transform.gameObject.tag == "Fire" && m_childOneLeading)
                {
                    //Deleting fire
                    m_childOne.SpellOne(hit.transform.gameObject);
                   
                }
                if(hit.transform.gameObject.tag == "VineBlock" && m_childOne.tag == "ForestChild")
                {
                    StartCoroutine(ClimbVines());
                }
            }
            
            
        }

        //Single Mouse Right click
        if (Input.GetMouseButtonDown(1)) 
        {
            SwitchCharaPos();
        }
    }

    //Checks who is leading and switches them with the backup chara
    //Handles animation
    public void SwitchCharaPos()
    {
        if (m_childOneLeading)
        {
            SwitchPos(m_childOne, m_childTwo);

            //Play animations
            m_childOneLeading = false;

        }
        else
        {
            SwitchPos(m_childTwo, m_childOne);

            //Play animations
            m_childOneLeading = true;
        }
        Debug.Log("Child leading: " + ((m_childOneLeading) ? m_childOne.tag : m_childTwo.tag));
    }

    //Switches positions of two players
    private void SwitchPos(Player _p1, Player _p2)
    {
        
        //Switches backup player to the front
        _p2.transform.position = m_selectedPos.transform.position;

        //Switches leading player to the back
        _p1.transform.position = m_backupPos[Random.Range(0, 3)].transform.position;
    }


    //Start Coroutine
    IEnumerator ClimbVines()
    {
        //Spawn Vines
        Vine1.SetActive(true);
        Vine2.SetActive(true);
        //Wait
        yield return new WaitForSeconds(2);
        //Teleport up
    }
}
