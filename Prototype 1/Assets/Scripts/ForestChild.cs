using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForestChild : Player
{
    public GameObject BothCharacters;
    public GameObject vine;
    public GameObject VineAnchorPnt;
    private Vector3 temp;
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

            BothCharacters.transform.position = new Vector3(BothCharacters.transform.position.x, Mathf.Lerp(BothCharacters.transform.position.y, VineAnchorPnt.transform.position.y, Time.deltaTime * fracComplete), BothCharacters.transform.position.z);
            
            if (BothCharacters.transform.position.y > VineAnchorPnt.transform.position.y - 0.01 && BothCharacters.transform.position.y <= VineAnchorPnt.transform.position.y )
            {
                BothCharacters.transform.position = new Vector3(Mathf.Lerp(BothCharacters.transform.position.x, VineAnchorPnt.transform.position.x, Time.deltaTime * fracComplete), BothCharacters.transform.position.y, Mathf.Lerp(BothCharacters.transform.position.z, VineAnchorPnt.transform.position.z, Time.deltaTime * fracComplete));
            }

            
        }
        
        if (BothCharacters.transform.position == temp)
        {
            BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
            ClimbingVines = false;
        }
      
    }

    public override void SpellOne(GameObject _Vines)
    {

        if (m_currAbilityCount > 0)
        {
            m_currAbilityCount -= 0;

            if (_Vines.tag == "VineBlock")
            { ClimbingVines = true;
            }
            else if (_Vines.tag == "Ground")
            {
                IsDecending = true;
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

    
    private IEnumerator Decending(GameObject _SelectedBlock)
    {
        m_isCasting = true;
      // yield return new Wait
        
        Vector3 temp = new Vector3(0, _SelectedBlock.transform.position.y / 2, 0);
        //play animation
        BothCharacters.GetComponent<NavMeshAgent>().enabled = false;
        BothCharacters.transform.position = _SelectedBlock.transform.position + temp;
        BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
          
        
        m_isCasting = false;
        yield return null;
    }

}
