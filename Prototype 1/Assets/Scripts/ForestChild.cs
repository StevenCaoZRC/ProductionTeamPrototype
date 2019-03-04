using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForestChild : Player
{
    public float m_timeStarted;
    public float m_lerpTime = 4;
    public float m_totalDistance;

    public bool m_climbingVines = false;
    public bool m_isDecending = false;
    public bool m_canBePlayed = false;

    private GameObject m_bothCharacters;
    private PlayerControl m_playerCtrl;
    private GameObject m_vineToCheck;
    private GameObject m_targetBlock;
    private GameObject[] m_vineBlocks;
    private AudioManager audioMnger;



    // Start is called before the first frame update
    void Awake()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Climbing();
        Decending();
    }

    public override void Reset()
    {
        m_charaElement = Element.Forest;

        m_currAbilityCount = LevelLoader.GetInstance().GetLvlForestMana();
        m_maxAbilityCount = LevelLoader.GetInstance().GetLvlMaxForestMana();
        m_climbingVines = false;
        m_isDecending = false;
        m_canBePlayed = false;

        audioMnger = FindObjectOfType<AudioManager>();
        m_bothCharacters = transform.parent.gameObject;


        m_timeStarted = Time.time;

        GameObject[] temp = new GameObject[GameObject.FindGameObjectsWithTag("VineBlock").Length];
        temp = GameObject.FindGameObjectsWithTag("VineBlock");
        temp.CopyTo(temp, 0);
        m_vineBlocks = temp;

        for (int i = 0; i < m_vineBlocks.Length; i++)
        {
            m_vineBlocks[i].transform.GetChild(3).gameObject.SetActive(false);
            m_vineBlocks[i].transform.GetChild(4).gameObject.SetActive(false);
        }
    }


    public override void SpellOne(GameObject _vineBlock)
    {
        //Standing above a vine block, Need to get down.
        if (m_currAbilityCount > 0)
        {
            m_bothCharacters.GetComponent<NavMeshAgent>().enabled = false;

            //If vines not active
            if (!_vineBlock.transform.GetChild(3).gameObject.activeSelf
             && !_vineBlock.transform.GetChild(4).gameObject.activeSelf)
            {
                m_currAbilityCount -= 1;
                m_isDecending = true;
                _vineBlock.transform.GetChild(3).gameObject.SetActive(true);
                _vineBlock.transform.GetChild(4).gameObject.SetActive(true);
                m_targetBlock = _vineBlock.transform.GetChild(6).gameObject;


            }
            else
            {
                m_isDecending = true;
                m_targetBlock = _vineBlock.transform.GetChild(6).gameObject;

                m_canBePlayed = true;
            }
        }
    }

    public override void SpellTwo(GameObject _vineBlock)
    {
        Debug.Log("AT THE BOT");
        if (m_currAbilityCount > 0)
        {
            //If not active
            m_bothCharacters.GetComponent<NavMeshAgent>().enabled = false;

            if (!_vineBlock.transform.GetChild(3).gameObject.activeSelf &&
            !_vineBlock.transform.GetChild(4).gameObject.activeSelf)
            {
                m_currAbilityCount -= 1;
                m_climbingVines = true;
                _vineBlock.transform.GetChild(3).gameObject.SetActive(true);
                _vineBlock.transform.GetChild(4).gameObject.SetActive(true);
                m_targetBlock = _vineBlock;


            }
            else //if active
            {
                m_climbingVines = true;
                m_targetBlock = _vineBlock;

                m_canBePlayed = true;

            }
        }
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerptime)
    {
        float timeSinceStart = 5 - timeStartedLerping;

        float percentageOfComplete = timeSinceStart / lerptime * Time.deltaTime;

        var result = Vector3.Lerp(start, end, percentageOfComplete);

        return result;
    }

    public void Climbing()
    {
        if (m_climbingVines == true)
        {
            Debug.Log("Climbign: " + m_canBePlayed);

            if (m_canBePlayed)
            {
                audioMnger.Play("ClimbingVine");
            }
            m_canBePlayed = false;

            Vector3 EndPostionPT1 = new Vector3(m_bothCharacters.transform.position.x,
                                                m_targetBlock.transform.GetChild(0).transform.position.y,
                                                m_bothCharacters.transform.position.z);

            m_totalDistance = Vector3.Distance(m_bothCharacters.transform.position, EndPostionPT1);
            m_bothCharacters.transform.position = Lerp(m_bothCharacters.transform.position, EndPostionPT1, m_timeStarted, m_totalDistance);


            if (m_bothCharacters.transform.position.y == m_targetBlock.transform.GetChild(0).transform.position.y)
            {
                Vector3 EndPostionPT2 = new Vector3(m_targetBlock.transform.GetChild(0).transform.position.x,
                                                   m_bothCharacters.transform.position.y,
                                                   m_targetBlock.transform.GetChild(0).transform.position.z);

                m_totalDistance = Vector3.Distance(m_bothCharacters.transform.position, EndPostionPT2);
                m_bothCharacters.transform.position = Lerp(m_bothCharacters.transform.position, EndPostionPT2, m_timeStarted, m_totalDistance);
            }
            if (m_bothCharacters.transform.position == m_targetBlock.transform.GetChild(0).transform.position)
            {
                m_bothCharacters.GetComponent<NavMeshAgent>().enabled = true;
                m_climbingVines = false;
                audioMnger.Stop("ClimbingVine");
            }
        }
    }

    public void Decending()
    {
        if (m_isDecending == true)
        {
            Debug.Log("Descending: " + m_canBePlayed);
            if (m_canBePlayed)
            {
                audioMnger.Play("ClimbingVine");
            }
            m_canBePlayed = false;

            Vector3 EndPostionPT1 = new Vector3(m_targetBlock.transform.position.x,
                                                m_bothCharacters.transform.position.y,
                                                m_targetBlock.transform.position.z);

            m_totalDistance = Vector3.Distance(m_bothCharacters.transform.position, EndPostionPT1);
            m_bothCharacters.transform.position = Lerp(m_bothCharacters.transform.position, EndPostionPT1, m_timeStarted, m_totalDistance);

            //yield return new WaitUntil(()=> BothCharacters.transform.position.y == vine.transform.GetChild(0).transform.position.y);
            if (m_bothCharacters.transform.position.x == m_targetBlock.transform.position.x && m_bothCharacters.transform.position.z == m_targetBlock.transform.position.z)
            {
                Vector3 EndPostionPT2 = new Vector3(m_targetBlock.transform.position.x,
                                                   m_targetBlock.transform.position.y + 1,
                                                  m_targetBlock.transform.position.z);

                m_totalDistance = Vector3.Distance(m_bothCharacters.transform.position, EndPostionPT2);
                m_bothCharacters.transform.position = Lerp(m_bothCharacters.transform.position, EndPostionPT2, m_timeStarted, m_totalDistance);
            }
            if (m_bothCharacters.transform.position.y == m_targetBlock.transform.position.y + 1)
            {
                m_bothCharacters.GetComponent<NavMeshAgent>().enabled = true;
                m_isDecending = false;
                audioMnger.Stop("ClimbingVine");

            }
        }




    }

}
