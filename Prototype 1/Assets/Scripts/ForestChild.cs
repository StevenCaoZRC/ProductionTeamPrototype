using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForestChild : Player
{
    public float timeStarted;
    public float lerpTime = 4;
    public float totalDistance;
    public GameObject BothCharacters;
    private GameObject[] m_vineBlocks;

    private PlayerControl playerCtrl;
    private GameObject m_vineToCheck;

    private GameObject m_targetBlock;
    private GameObject decendingVine;
    private Vector3 temp;

    private GameObject m_decendingLoc;
    public bool m_climbingVines = false;
    public bool  m_isDecending  = false;
  
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
        m_currAbilityCount = 4;
        m_maxAbilityCount = 4;

        timeStarted = Time.time;

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
            BothCharacters.GetComponent<NavMeshAgent>().enabled = false;

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
            }
        }
    }

    public override void SpellTwo(GameObject _vineBlock)
    {
        Debug.Log("AT THE BOT");
        if(m_currAbilityCount > 0)
        {
            //If not active
            BothCharacters.GetComponent<NavMeshAgent>().enabled = false;

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
            }
        }
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerptime)
    {
        float timeSinceStart = 5 - timeStartedLerping  ;

        float percentageOfComplete = timeSinceStart / lerptime * Time.deltaTime;

        var result = Vector3.Lerp(start, end, percentageOfComplete);
        
        return result;
    }

    public void Climbing()
    {
        if (m_climbingVines == true)
        {
            Vector3 EndPostionPT1 = new Vector3(BothCharacters.transform.position.x,
                                                m_targetBlock.transform.GetChild(0).transform.position.y,
                                                BothCharacters.transform.position.z);

            totalDistance = Vector3.Distance(BothCharacters.transform.position, EndPostionPT1);
            BothCharacters.transform.position = Lerp(BothCharacters.transform.position, EndPostionPT1, timeStarted,totalDistance );

           
            if(BothCharacters.transform.position.y == m_targetBlock.transform.GetChild(0).transform.position.y)
            {
                Vector3 EndPostionPT2 = new Vector3(m_targetBlock.transform.GetChild(0).transform.position.x,
                                                   BothCharacters.transform.position.y,
                                                   m_targetBlock.transform.GetChild(0).transform.position.z);

                totalDistance = Vector3.Distance(BothCharacters.transform.position, EndPostionPT2);
                BothCharacters.transform.position = Lerp(BothCharacters.transform.position, EndPostionPT2, timeStarted, totalDistance);
            }
            if (BothCharacters.transform.position == m_targetBlock.transform.GetChild(0).transform.position)
            {
                BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
                m_climbingVines = false;
            }
        }
    }
    
    public void Decending()
    {
        if (m_isDecending == true)
        {
            Vector3 EndPostionPT1 = new Vector3(m_targetBlock.transform.position.x,
                                                BothCharacters.transform.position.y,
                                                m_targetBlock.transform.position.z);

            totalDistance = Vector3.Distance(BothCharacters.transform.position, EndPostionPT1);
            BothCharacters.transform.position = Lerp(BothCharacters.transform.position, EndPostionPT1, timeStarted, totalDistance);

            //yield return new WaitUntil(()=> BothCharacters.transform.position.y == vine.transform.GetChild(0).transform.position.y);
            if (BothCharacters.transform.position.x == m_targetBlock.transform.position.x && BothCharacters.transform.position.z == m_targetBlock.transform.position.z)
            {
                Vector3 EndPostionPT2 = new Vector3(m_targetBlock.transform.position.x,
                                                   m_targetBlock.transform.position.y + 1,
                                                  m_targetBlock.transform.position.z);

                totalDistance = Vector3.Distance(BothCharacters.transform.position, EndPostionPT2);
                BothCharacters.transform.position = Lerp(BothCharacters.transform.position, EndPostionPT2, timeStarted, totalDistance);
            }
            if (BothCharacters.transform.position.y == m_targetBlock.transform.position.y + 1)
            {
                BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
                m_isDecending = false;
            }
        }
       



    }

}
