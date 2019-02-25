using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForestChild : Player
{
    public GameObject BothCharacters;
    public GameObject[] VineBlocks;
    public GameObject VineAnchorPnt;
    private PlayerControl playerCtrl;
    private GameObject CheckVine;
    private GameObject vine;
    private Vector3 temp;
    private GameObject DecendingLoc;
    public bool ClimbingVines = false;
    public bool  IsDecending  = false;
    // Start is called before the first frame update
    void Awake()
    {
        m_charaElement = Element.Forest;
        m_currAbilityCount = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if (ClimbingVines == true)
        {
            BothCharacters.GetComponent<NavMeshAgent>().enabled = false;
            Vector3 CurrentPlayerLocation = BothCharacters.transform.GetChild(0).transform.position;

            float fracComplete = 5.0f;

            //player.transform.position = transform.position + temp;\
            temp = new Vector3(vine.transform.position.x, vine.transform.position.y+(vine.transform.position.y / 2), vine.transform.position.z);

            BothCharacters.transform.position = new Vector3(BothCharacters.transform.position.x, Mathf.Lerp(BothCharacters.transform.position.y, vine.transform.GetChild(0).transform.position.y, Time.deltaTime * fracComplete), BothCharacters.transform.position.z);
            
            if (BothCharacters.transform.position.y > vine.transform.GetChild(0).transform.position.y - 0.01 && BothCharacters.transform.position.y <= vine.transform.GetChild(0).transform.position.y )
            {
                BothCharacters.transform.position = new Vector3(Mathf.Lerp(BothCharacters.transform.position.x, vine.transform.GetChild(0).transform.position.x, Time.deltaTime * fracComplete), BothCharacters.transform.position.y, Mathf.Lerp(BothCharacters.transform.position.z, vine.transform.GetChild(0).transform.position.z, Time.deltaTime * fracComplete));
            }
        }
        if (BothCharacters.transform.position == temp)
        {
            BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
            ClimbingVines = false;
            
        }
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
                    }
                }
            }
            else if (_Vines.tag == "Ground")
            {
                IsDecending = true;
                DecendingLoc = _Vines;
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

    
    public void Decending()
    {

        if (IsDecending == true)
        {
            BothCharacters.GetComponent<NavMeshAgent>().enabled = false;
            Vector3 CurrentPlayerLocation = BothCharacters.transform.GetChild(0).transform.position;

            float fracComplete =1.0f;

            //player.transform.position = transform.position + temp;\
            temp = new Vector3(DecendingLoc.gameObject.transform.position.x, DecendingLoc.transform.position.y + (DecendingLoc.transform.position.y / 2), DecendingLoc.gameObject.transform.position.z);


            //BothCharacters.transform.position = new Vector3(Mathf.Lerp(BothCharacters.transform.position.x, DecendingLoc.transform.position.x, Time.deltaTime * fracComplete), BothCharacters.transform.position.y, Mathf.Lerp(BothCharacters.transform.position.z, DecendingLoc.transform.position.z, Time.deltaTime * fracComplete));
            BothCharacters.transform.position = Vector3.Lerp(BothCharacters.transform.position, DecendingLoc.transform.position, Time.deltaTime); 

            if (BothCharacters.transform.position.x > DecendingLoc.transform.position.x - 0.01 && BothCharacters.transform.position.x <= DecendingLoc.transform.position.x)
            {
                BothCharacters.transform.position = new Vector3(BothCharacters.transform.position.x, Mathf.Lerp(BothCharacters.transform.position.y, DecendingLoc.transform.position.y, Time.deltaTime * fracComplete), BothCharacters.transform.position.z);
            }
        }
        if (BothCharacters.transform.position == temp)
        {
            BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
            IsDecending = false;
        }



    }

}
