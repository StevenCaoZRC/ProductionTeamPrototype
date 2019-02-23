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
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void SpellOne(GameObject _Vines)
    {
        if (_Vines.tag == "VineBlock")
        { StartCoroutine(ClimbVines(_Vines)); }
        else if (_Vines.tag == "Ground")
        {
            StartCoroutine(Decending(_Vines));
        }


    }

    public override void SpellTwo(GameObject _waterBlock)
    {

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
        
        Vector3 temp = new Vector3(0, _SelectedBlock.transform.position.y / 2, 0);
        //play animation
        BothCharacters.GetComponent<NavMeshAgent>().enabled = false;
        BothCharacters.transform.position = _SelectedBlock.transform.position + temp;
        BothCharacters.GetComponent<NavMeshAgent>().enabled = true;
          
        
        m_isCasting = false;
        yield return null;
    }

}
