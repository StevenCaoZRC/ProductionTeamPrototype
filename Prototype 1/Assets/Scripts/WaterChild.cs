using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WaterChild : Player
{
    AudioManager AudioMger;
    // Start is called before the first frame update
    void Awake()
    {
        Reset();
        AudioMger = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public override void Reset()
    {
        m_charaElement = Element.Water;
        m_currAbilityCount = 3;
        m_maxAbilityCount = 3;
    }

    public override void SpellOne(GameObject _fire)
    {
        //put out fire
        if(m_currAbilityCount > 0 && !m_isCasting)
        {
           
            m_currAbilityCount -= 1;
            m_isCasting = true;
            StartCoroutine(PutOutFire(_fire));
           
        }
    }
    public override void SpellTwo(GameObject _waterBlock)
    {
        //Create ice block in river
        if (m_currAbilityCount > 0 && !m_isCasting 
            && _waterBlock.GetComponent<WaterBlock>().GetBlockType() == BlockType.Water)
        {
         
            m_currAbilityCount -= 1;
            m_isCasting = true;

            StartCoroutine(CastIceBlock(_waterBlock));
           
        }
    }

    private IEnumerator PutOutFire(GameObject _fire)
    {
        m_childAnim.SetTrigger("WCWater");

        //Play fire dying animation 
        yield return new WaitForSeconds(2);

        _fire.transform.parent.parent.GetComponent<FireBlock>().PutOutFire();

        m_isCasting = false;

        yield return null;
    }
    // m_childAnim.SetTrigger("WCFidget");
    private IEnumerator CastIceBlock(GameObject _water)
    {
        m_childAnim.SetTrigger("WCIce");
        yield return new WaitForSeconds(1.5f);

        //Play fire dying animation 
        _water.gameObject.GetComponent<WaterBlock>().CreateIce();
        yield return new WaitForSeconds(2.5f);
       
        //Make it walkable only after animation is done
        _water.gameObject.GetComponent<WaterBlock>().SetWalkable(true);
        //Spawn ice block in water block. float.
        AudioMger.Play("IceCubeDrop");
        m_isCasting = false;
       
         yield return null;
    }

}
