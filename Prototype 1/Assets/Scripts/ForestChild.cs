using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForestChild : Player
{
    public GameObject BothCharacters;
    // Start is called before the first frame update
    void Awake()
    {
       
        m_charaElement = Element.Forest;
        m_currAbilityCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void SpellOne(GameObject _Vines)
    {
        
        if (_Vines.tag == "VineBlock")
        {
            if (!_Vines.transform.GetComponent<VineBlock>().GetVinesSpawned() && m_currAbilityCount > 0)
            {
                m_currAbilityCount -= 1;
            }

            StartCoroutine(ClimbVines(_Vines));
        }

        if (_Vines.tag == "Ground")
        {
            Debug.Log("DFKGJHDFKSBGKDFBG");


            StartCoroutine(Decending(_Vines));
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

    private IEnumerator ClimbVines(GameObject _Vines)
    {
        m_isCasting = true;
        //yield return new WaitForSeconds(2);

        _Vines.transform.GetComponent<VineBlock>().ClimbingVines();
        m_isCasting = false;
        yield return null;
    }
    private IEnumerator Decending(GameObject _SelectedBlock)
    {
        m_isCasting = true;
        //yield return new WaitForSeconds(2);
        Debug.Log("im a nerd");
        Vector3 temp = new Vector3(0, _SelectedBlock.transform.position.y / 2, 0);
        //play animation
        BothCharacters.GetComponent<NavMeshAgent>().enabled = false;
        BothCharacters.transform.position = _SelectedBlock.transform.position + temp;
        BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
          
        
        m_isCasting = false;
        yield return null;
    }

}
