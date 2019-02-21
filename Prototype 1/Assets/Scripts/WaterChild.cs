using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterChild : Player
{

    // Start is called before the first frame update
    void Awake()
    {
        m_charaElement = Element.Water;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SpellOne(GameObject _fire)
    {
        //put out fire
        StartCoroutine(PutOutFire(_fire));
    }
    public override void SpellTwo(GameObject _waterBlock)
    {
        //Create ice block in river
        StartCoroutine(CastIceBlock(_waterBlock));
    }

    private IEnumerator PutOutFire(GameObject _fire)
    {
        m_isCasting = true;

        //Play fire dying animation 
        yield return new WaitForSeconds(2);
        _fire.transform.parent.gameObject.SetActive(false);

        m_isCasting = false;

        yield return null;
    }

    private IEnumerator CastIceBlock(GameObject _river)
    {
        m_isCasting = true;

        //_river.

        //Play fire dying animation 
        yield return new WaitForSeconds(2);

        //Spawn ice block in water block. float.

        m_isCasting = false;

        yield return null;
    }

}
