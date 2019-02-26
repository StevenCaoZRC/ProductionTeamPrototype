﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForestChild : Player
{
    public float timeStarted;
    public float lerpTime = 4;
    public float totalDistance;
    public GameObject BothCharacters;
    public GameObject[] VineBlocks;

    private PlayerControl playerCtrl;
    private GameObject CheckVine;

    private GameObject vine;
    private Vector3 temp;

    private GameObject DecendingLoc;
    public bool ClimbingVines = false;
    public bool  IsDecending  = false;
  
    // Start is called before the first frame update
    void Start()
    {
        timeStarted = Time.time;
        for (int i = 0; i < VineBlocks.Length; i++)
        {
            VineBlocks[i].transform.GetChild(3).gameObject.SetActive(false);
            VineBlocks[i].transform.GetChild(4).gameObject.SetActive(false);
        }

    }
    void Awake()
    {
        m_charaElement = Element.Forest;
        m_currAbilityCount = 1; 
    }
    // Update is called once per frame
    void Update()
    {
        Climbing();
        Decending(); 
    }
    public override void SpellOne(GameObject _Vines)
    {

        if (m_currAbilityCount > 0)
        {
            m_currAbilityCount -= 0;

            if (_Vines.tag == "VineBlock")
            { ClimbingVines = true;
                CheckVine = _Vines;
                for (int i = 0; i < VineBlocks.Length; i++)
                {
                    if (VineBlocks[i].name == CheckVine.name)
                    {
                        vine = VineBlocks[i];
                        VineBlocks[i].transform.GetChild(3).gameObject.SetActive(true);
                        VineBlocks[i].transform.GetChild(4).gameObject.SetActive(true);
                    }
                }
                BothCharacters.GetComponent<NavMeshAgent>().enabled = false;
            }
            else if (_Vines.tag == "Ground" && BothCharacters.transform.position.x == vine.transform.GetChild(0).transform.position.x && BothCharacters.transform.position.z == vine.transform.GetChild(0).transform.position.z)
            {
                Debug.Log("VineGround DESCEND: " + IsDecending);

                IsDecending = true;
                DecendingLoc = _Vines;
                BothCharacters.GetComponent<NavMeshAgent>().enabled = false;
            }
        }

    }
    public override void SpellTwo(GameObject _waterBlock)
    {
        if (m_currAbilityCount > 0)
        {
            m_currAbilityCount -= 1;

            //Do spell
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
        
        if (ClimbingVines == true)
        {
            Vector3 EndPostionPT1 = new Vector3(BothCharacters.transform.position.x,
                                                vine.transform.GetChild(0).transform.position.y,
                                                BothCharacters.transform.position.z);

            totalDistance = Vector3.Distance(BothCharacters.transform.position, EndPostionPT1);
            BothCharacters.transform.position = Lerp(BothCharacters.transform.position, EndPostionPT1, timeStarted,totalDistance );

           
            if(BothCharacters.transform.position.y == vine.transform.GetChild(0).transform.position.y)
            {
                Vector3 EndPostionPT2 = new Vector3(vine.transform.GetChild(0).transform.position.x,
                                                   BothCharacters.transform.position.y,
                                                  vine.transform.GetChild(0).transform.position.z);

                totalDistance = Vector3.Distance(BothCharacters.transform.position, EndPostionPT2);
                BothCharacters.transform.position = Lerp(BothCharacters.transform.position, EndPostionPT2, timeStarted, totalDistance);
            }
            if (BothCharacters.transform.position == vine.transform.GetChild(0).transform.position)
            {
                BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
                ClimbingVines = false;
            }
        
            
            
            //  old code steven
            /*Vector3 CurrentPlayerLocation = BothCharacters.transform.GetChild(0).transform.position;

            float fracComplete = 5.0f;
            
            //player.transform.position = transform.position + temp;\
            temp = new Vector3(vine.transform.position.x, vine.transform.position.y + (vine.transform.position.y / 2), vine.transform.position.z);

            BothCharacters.transform.position = new Vector3(BothCharacters.transform.position.x, Mathf.Lerp(BothCharacters.transform.position.y, vine.transform.GetChild(0).transform.position.y, Time.deltaTime * fracComplete), BothCharacters.transform.position.z);

            if (BothCharacters.transform.position.y > vine.transform.GetChild(0).transform.position.y - 0.01 && BothCharacters.transform.position.y <= vine.transform.GetChild(0).transform.position.y)
            {
                BothCharacters.transform.position = new Vector3(Mathf.Lerp(BothCharacters.transform.position.x, vine.transform.GetChild(0).transform.position.x, Time.deltaTime * fracComplete), BothCharacters.transform.position.y, Mathf.Lerp(BothCharacters.transform.position.z, vine.transform.GetChild(0).transform.position.z, Time.deltaTime * fracComplete));
            }
        
            if (BothCharacters.transform.position == temp)
            {
                BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
                ClimbingVines = false;

            }*/
        }
    }
    
    public void Decending()
    {

        if (IsDecending == true)
        {
            Debug.Log("yaALLL DESCEND: " + IsDecending);

            Vector3 EndPostionPT1 = new Vector3(DecendingLoc.transform.position.x,
                                                BothCharacters.transform.position.y,
                                                DecendingLoc.transform.position.z);

            totalDistance = Vector3.Distance(BothCharacters.transform.position, EndPostionPT1);
            BothCharacters.transform.position = Lerp(BothCharacters.transform.position, EndPostionPT1, timeStarted, totalDistance);

            //yield return new WaitUntil(()=> BothCharacters.transform.position.y == vine.transform.GetChild(0).transform.position.y);
            if (BothCharacters.transform.position.x == DecendingLoc.transform.position.x && BothCharacters.transform.position.z == DecendingLoc.transform.position.z)
            {
                Vector3 EndPostionPT2 = new Vector3(DecendingLoc.transform.position.x,
                                                   DecendingLoc.transform.position.y ,
                                                  DecendingLoc.transform.position.z);

                totalDistance = Vector3.Distance(BothCharacters.transform.position, EndPostionPT2);
                BothCharacters.transform.position = Lerp(BothCharacters.transform.position, EndPostionPT2, timeStarted, totalDistance);
            }
            if (BothCharacters.transform.position == DecendingLoc.transform.position)
            {
                BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
                IsDecending = false;
            }
        }
       



    }

}
