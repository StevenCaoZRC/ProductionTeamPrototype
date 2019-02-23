using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ForestChild : Player
{
    
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
       StartCoroutine(ClimbVines(_Vines));
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
}
